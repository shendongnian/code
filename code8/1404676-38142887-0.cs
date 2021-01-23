    using System;
    public abstract class MyObject<T> {
        public static TOtherObject FromObject<TOtherObject>(TOtherObject anotherObject) where TOtherObject : MyObject<T> {
            var newOtherTypeInstance = Activator.CreateInstance<TOtherObject>();
            //  some reflection logic here
            return newOtherTypeInstance;
        }
    }
    public class ProductCart : MyObject<ProductCart> {
    }
    public class Basket : ProductCart {
        public int BasketId { get; set; }
    }
    public class Order : ProductCart {
        public int OrderId { get; set; }
    }
    class Program {
        static void Main(string[] args) {
            Order o = new Order();
            var basket = Basket.FromObject(o);
        }
    }
