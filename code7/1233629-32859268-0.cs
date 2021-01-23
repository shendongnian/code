    public class Holded: IHolded { ... }
    public class Inventory
    {
         public Inventory(IHolded holded) { ... }
         public IHolded Holded { get; }
    }
    public Equipment
    {
         public Equipment(IHolded holded) {...}
         public IHolded Holded { get; }
    }
