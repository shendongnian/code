    public interface IProductPromoCodeRepository
    {
        // You can see that these are similar to the methods that the IBaseRepository interface defines, so you can actually make this one inherit from it.
        ProductPromoCode Get(string code, string id, string country);
        void Create(ProductPromoCode item);
        void Update(ProductPromoCode item);
    }
