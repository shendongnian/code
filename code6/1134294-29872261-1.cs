    public static class MyConversionExtensions
    {
        public static IEnumerable<ShipmentDetailsDTO> ToShipmentDetails(this RootObject root)
        {
            return root.BaseOrderShipmentLineitem.Select(x => new ShipmentDetailsDTO() {
                BaseOrderShipmentLineitemId = x.BaseOrderLineitem.Id,
                BaseSupplierName = root.BaseSupplier.Name,
                Sku = x.BaseOrderLineitem.ProductSku
            });
        }
    }
