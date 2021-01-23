    var gropString = String.Format("new ({0})", GroupDocumentByFields().ToSeparatedString());
    var groupping = list1.AsQueryable().GroupBy(gropString, "it");
    foreach (IGrouping<dynamic, ITAP.Database.OrderItems> items in groupping) {
         var idorders = items.Select(p => p.IDOrder).Distinct().ToList();
         var goods = listGoods.Where(p => idorders.Contains(p.IDOrder));
         var services = listServices.Where(p => idorders.Contains(p.IDOrder));
...
     protected List<string> GroupDocumentItemsByFields() {
            var fields = new List<string>();
            if (GetNameVariant == Selling.GetNameVariant.OrderItemsName)
                fields.Add("Name as ItemName");
            if (GetNameVariant == Selling.GetNameVariant.OrderItemsShortName)
                fields.Add("ShortName as ItemName");
            if (GetNameVariant == Selling.GetNameVariant.SellingName)
                fields.Add("SellingName as ItemName");
            if(this.PriceVariant == Selling.PriceVariant.PriceWithoutNDS)
                fields.Add("PriceWithoutNDS as Price");
            if (this.PriceVariant == Selling.PriceVariant.Price)
                fields.Add("Price as Price");
            return fields;            
        }
