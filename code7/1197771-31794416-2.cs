    class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
    
    class AnimeComparer: IEqualityComparer<Anime>
    {
    	public bool Equals(Anime a1, Anime a2)
        {
            return (a1.Id==a2.Id);
        }
    
    
        public int GetHashCode(Anime a)
        {
            return a.Id;
        }
    }
    
    void Main()
    {
    	var a1=new Anime[]{new Anime {Id=1,Title="Title1"},new Anime {Id=2,Title="Title2"}};
    	var a2=new Anime[]{new Anime {Id=2,Title="Title2"},new Anime {Id=3,Title="Title3"}};
    	var a3=a1.Intersect(a2,new AnimeComparer());
    	a3.Dump();
    }
