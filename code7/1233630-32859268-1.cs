    public interface IHolded
    {
         Bar Foo();
    }
    public class Holded: IHolded { ... }
    public class Inventory
    {
         public Inventory(IHolded holded) { ... }
         public IHolded Holded { get; }
    }
