    public interface IDiscount
    {
        // method or property signatures
    }
    public class BasicDiscount : IDiscount
    {
        // implementation of interface members
    }
    public IDiscount getDiscount(Product p)
    {
         (IDiscount) discount;
         foreach (BasicDiscount b in BasicDiscounts)
             if (b.Product.ID == p.ID)
                 discount = b;
         foreach (AdvancedDiscount ad in AdvancedDiscounts)
             if (ad.Product.ID == p.ID)
                 discount = ad;
         foreach (SuperDiscount sd in SuperDiscounts)
             if (sd.Product.ID == p.ID)
                 discount = sd;
         return discount;
    }
