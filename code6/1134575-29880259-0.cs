    void Main()
    {
    	List<Music> myMusic = new List<Music>
    	{
    		new Music 
    		{ 
    			Artist = "Mozart", 
    			Album = "Mozarts amazing album", 
    			TotalTracks = int.MaxValue, 
    			Etc = int.MinValue
    		},
    		new Music 
    		{ 
    			Artist = "Foo", 
    			Album = "Bar", 
    			TotalTracks = int.MaxValue, 
    			Etc = int.MinValue
    		},
    	};
    	
    	
    	var mozartsMusic = myMusic.Where(music => music.Artist == "Mozart")
    							  .ToList();
    	
    	mozartsMusic.ForEach(Console.WriteLine);
    	
    }
    
    public class Music
    {
    	public string Artist { get; set; }
    	public string Album { get; set; }
    	public int TotalTracks { get; set; }
    	public int Etc { get; set; }
    	
    	public override string ToString()
    	{
    		return string.Join("\n",this.GetType().GetProperties().Select(p=>string.Format("{0} {1}", p.Name, p.GetValue(this))));
    	}
    }
