    //only initialized when it's used
    private static Lazy<List<Meat>> meatList 
         = new Lazy<List<Meat>>(
                 () =>
                 {
                     //load single list here
                 }
         );
    public List<Meat> MeatList { get{ return meanList.Value; } }
