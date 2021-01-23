    public class ProductUpdateParameter : DataTable
    {
        public ProductUpdateParameter()
        {
            Columns.Add("productId", typeof (int));
            Columns.Add("propertyId", typeof (int));
            Columns.Add("propertyValue", typeof (string));
            Columns[2].MaxLength = 20;
        }
        public void AddProductUpdate(int productId, int propertyId, string propertyValue)
        {
            Rows.Add(productId, propertyId, propertyValue);
        }
    }
