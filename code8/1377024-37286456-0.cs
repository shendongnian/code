    public interface IEntity {}
    
    public interface IFruit : IEntity {}
    
    public class PurchasedItem
    {
        public int Qty {get;set;}
    }
    
    public class Apple : PurchaseItem, IFruit {}
    public class Orange: PurchaseItem, IFruit {}
    
    var list = new List<PurchaseItem>();
