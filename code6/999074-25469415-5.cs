    public class DAL
    {
        public static DataTable GetMockData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductId", Type.GetType("System.Int32"));
            dt.Columns.Add("ProductName", Type.GetType("System.String"));
            dt.Columns.Add("ProductCategory", Type.GetType("System.String"));
            dt.Rows.Add(new object[] { 1, "Apple", "Fruit" });
            dt.Rows.Add(new object[] { 2, "Banana", "Fruit" });
            dt.Rows.Add(new object[] { 3, "Pear", "Fruit" });
            dt.Rows.Add(new object[] { 4, "Potato", "Vegetable" });
            dt.Rows.Add(new object[] { 5, "Celery", "Vegetable" });
            dt.Rows.Add(new object[] { 6, "Carrot", "Vegetable" });
            dt.Rows.Add(new object[] { 7, "Hominy", "Vegetable" });
            dt.Rows.Add(new object[] { 8, "Wine", "Beverage" });
            dt.AcceptChanges();
            return dt;
        }
    }
