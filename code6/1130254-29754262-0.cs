    public static void Main()
    {
         var result = GetData("test").Sum(x => int.Parse(x.Name));
    	 Console.WriteLine(result);
    }
    	
    	public static List<dynamic> GetData(string x)
         {
             List<dynamic> data = new List<dynamic>
             {
                 new { Id =1, Name ="1"},
                 new { Id =2, Name ="4"},
                 new { Id =3, Name ="5"}
             };
             return data;
         }
