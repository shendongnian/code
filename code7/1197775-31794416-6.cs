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
            return a.Id.GetHashCode();
        }
    }
    
    void Main()
    {
    	var a1=new Anime[]{new Anime {Id=1,Title="Title1"},new Anime {Id=2,Title="Title2"}};
    	var a2=new Anime[]{new Anime {Id=2,Title="Title2"},new Anime {Id=3,Title="Title3"}};
    	
    	var ac=new AnimeComparer();
    	var q1=a1.Except(a2,ac);
    	var q2=a2.Except(a1,ac);
    	var q3=a1.Intersect(a2,ac);
    	q1.Dump();
    	q2.Dump();
    	q3.Dump();
    }
