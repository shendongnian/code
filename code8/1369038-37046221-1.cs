    public class StuffSearchInput
    {
        int ByA { get; set; }
        int ByB { get; set; }
    }
    public class StuffSearchOutput
    {
        int Id { get; set; }
        String Name { get; set; }
    }
    public StuffSearchOutput GetMyStuff(StuffSearchInput arguments)
    {
        StuffSearchOutput result = null;
        //find result using arguments;
        return result;
    }
