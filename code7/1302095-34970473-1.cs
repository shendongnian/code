public class MyViewModel
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public bool IsPeriod { get; set; }
    public RouteValueDictionary RouteValues
    {
        get
        {
            var rvd = new RouteValueDictionary();
            rvd["name"] = Name;
            rvd["surname"] = Surname;
            rvd["isPeriod"] = IsPeriod;
            return rvd;
        }
    }
}
