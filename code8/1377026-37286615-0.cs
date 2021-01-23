    public interface IEntity
    {
        int Id { get; set; }
    }
    public interface IFruit : IEntity
    {
    }
    public class Apple : IFruit
    {
        public int Id { get; set; }
    }
    public interface IPurchaseItem<out T> where T : IFruit
    {
        int Qty { get; set; }
        T Item { get; }
    }
    public class PurchaseItem<T> : IPurchaseItem<T>
        where T : IFruit
    {
        public int Qty { get; set; }
        public T Item { get; set; }
    }
    class Program
    {
        static void Main()
        {
            var applePurchaseItem = new PurchaseItem<Apple>();
            var fruitPurchaseItems = new List<IPurchaseItem<IFruit>>();
            fruitPurchaseItems.Add( applePurchaseItem );
        }
    }
