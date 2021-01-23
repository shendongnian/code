    public interface IEntity {}
    
    public interface IFruit : IEntity {}
    
    public class PurchasedItem
    {
        public int Qty { get; set; }
    }
    
    public class Apple : PurchasedItem, IFruit {}
    public class Orange: PurchasedItem, IFruit {}
    
    var list = new List<PurchasedItem>();
