    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var game = new SortingGame();
    		var random = new Random(234);
    
            // Simulate few concurrent players.
    		for (var i = 0; i < 3; i++)
    		{
    			ThreadPool.QueueUserWorkItem(o =>
    			{
    				while (!game.IsSorted())
    				{
    					var x = random.Next(game.Count() - 1);
    					game.PlayAt(x);
    					DumpGame(game);
    				};
    			});
    		}
    		
    		Thread.Sleep(4000);
    	
    		DumpGame(game);	
    	}
    	
    	static void DumpGame(SortingGame game)
    	{
    		var items = game.GetBoardSnapshot();
    		
    		Console.WriteLine(string.Join(",", items));
    	}
    }
    
    
    class SortingGame
    {
    	List<int> items;
    	List<object> lockers;
        // this lock is taken for the entire board to guard from inconsistent reads.
    	object entireBoardLock = new object();
    
    	public SortingGame()
    	{
    		const int N = 10;
            // Initialize a game with items in random order
    		var random = new Random(1235678);
    		var setup = Enumerable.Range(0, N).Select(i => new { x = i, position = random.Next(0, 100)}).ToList();
    		items = setup.OrderBy(i => i.position).Select(i => i.x).ToList();
    		lockers = Enumerable.Range(0, N).Select(i => new object()).ToList();
    	}
    
    	public int Count()
    	{
    		return items.Count;
    	}
    
    	public bool IsSorted()
    	{
    		var currentBoard = GetBoardSnapshot();
    		var pairs = currentBoard.Zip(currentBoard.Skip(1), (a, b) => new { a, b});
    		return pairs.All(p => p.a <= p.b);
    	}
    
    	public IEnumerable<int> GetBoardSnapshot()
    	{
    		lock (entireBoardLock)
    			return new List<int>(items);
    	}
    
    	public void PlayAt(int x)
    	{
            // Find the resource lockers for the two adjacent cells in question
    		var locker1 = GetLockForCell(x);
    		var locker2 = GetLockForCell(x + 1);
    
            // It's important to lock the resources in a particular order, same for all the contending writers and readers.
            // These can last for a long time, but are granular,
            // so the contention is greatly reduced.
    		// Try to remove one of the following locks, and notice the duplicate items in the result
    		lock (locker1)
    		lock (locker2)
    			{
    				var a = items[x];
    				var b = items[x + 1];
    				if (a > b)
    				{
                        // Simulate expensive computation
    					Thread.Sleep(100);
                        // Following is a lock to protect from incorrect game state read
                        // The lock lasts for a very short time.
    					lock (entireBoardLock)
    					{
    						items[x] = b;
    						items[x + 1] = a;
    					}
    				}			
    			}
    	}
    
    	object GetLockForCell(int x)
    	{
    		return lockers[x];
    	}
    }
