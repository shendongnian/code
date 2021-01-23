    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var players = new List<Player>
    		{
    			new Player("Orel", true),
    			new Player("Zeus"),
    			new Player("Hercules", true),
    			new Player("Nepton"),
    		};
    		
    		var playingPlayers = players.Where(p => p.IsPlaying);
    		foreach (var player in playingPlayers)
    		{
    			Console.WriteLine(player.Name);
    		}
    	}
    }
    
    public class Player
    {
    	public string Name { get; set; }
    	public bool IsPlaying { get; set; }
    	
    	public Player(string name, bool isPlaying = false)
    	{
    		Name = name;
    		IsPlaying = isPlaying;
    	}
    }
