    public class KnownSupplierIds
    {
        public const int FedEx = 1;
        public const int UPS = 2;
        // etc.
    }
    if (product.Supplier.SupplierId == KnownSupplierIds.Fedex) { ... };
