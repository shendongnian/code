    public static class MyConversionExtensions
    {
        public static IEnumerable<ShipmentDetailsDTO> ToShipmentDetails(this RootObject root)
        {
            return root.BaseOrderShipmentLineitem.Select(x => new ShipmentDetailsDTO() {
                BaseOrderId = x.Id,
                //CustomerOrderCode = ? UNCLEAR WHAT FIELD SHOULD BE MAPPED.
                //FulfillLoc = ? UNCLEAR WHAT FIELD SHOULD BE MAPPED.
                //BaseOrderShipmentInvoiceNumber = ? UNCLEAR WHAT FIELD SHOULD BE MAPPED.
                Sku = x.BaseOrderLineitem.ProductSku
            });
        }
    }
