    public class Store
    {
        public virtual Section Section { get; set; }
    }
    public class Section
    {
        public virtual Sqft Sqft { get; set; }
        public virtual ForwardSelling ForwardSelling { get; set; }
    }
    public void Method()
    {
        var secList = Context.Section.ToList();
        
        var sqftFromFirst = secList.First().Sqft.Measures;
    }
