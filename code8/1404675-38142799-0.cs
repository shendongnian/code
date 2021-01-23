    public class Basket : ProductCart
    {
        public int BasketId { get; set; }
        public Basket FromObject(object anotherObject)
        {
            return MyObject<Basket>.FromObject(anotherObject);
        }
    }
