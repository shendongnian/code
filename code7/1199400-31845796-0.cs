	public class Program
	{
		public static void Main()
		{
			new Program().Execute();
		}
		
		// Initial method that will fire the threads
		public void Execute()
		{
			// This object will be responsible to lock the objects
			this.fixErrorLock = new object();
			
			var objectsToIterate = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
			
			// For each element in the collection the given action will be executed passing the current item as parameter.
			//Parallel.ForEach(objectsToIterate, this.DoWork);
			
			objectsToIterate.AsParallel().ForAll(this.DoWork);
		}
		
		// By defaullt has a value of 'false'
		private bool errorFixed;
		private object fixErrorLock;
		
		public void DoWork(int myParam)
		{
			try
			{
				if(!this.errorFixed && myParam % 4 == 0)
				{
					throw new Exception();	
				}
				
				// Thread executed without error
			}catch(Exception ex)
			{
				// Thread will wait here if another thread is already inside the lock
				lock(fixErrorLock)
				{
					if(!this.errorFixed)
					{
						this.errorFixed = this.FixTheProblem(myParam);
					}
				}
				
				this.DoWork(myParam);
			}
		}
		
		public bool FixTheProblem(int param)
		{		
			// Fix the problem
			return true;
		}
	}
