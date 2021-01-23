    class Anime
    {
       public int Id { get; set; }
       public string Title { get; set; }
       public string ImageUrl { get; set; }
    }
    
    void Main()
    {
    	var a1=new Anime[]{new Anime {Id=1,Title="Title1"},new Anime {Id=2,Title="Title2"}};
    	var a2=new Anime[]{new Anime {Id=2,Title="Title2"},new Anime {Id=3,Title="Title3"}};
    
    	var q1=a1.ExceptBy(a2,k=>k.Id);
    	var q2=a2.ExceptBy(a1,k=>k.Id);
    	var q3=a1.ExceptBy(q1,k=>k.Id);
    	q1.Dump();
    	q2.Dump();
    	q3.Dump();
    }
