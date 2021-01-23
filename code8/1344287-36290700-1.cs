    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication2
    {
        public class MyStoreObject
        {
            public int StoreID { get; set; }
            public string StoreName { get; set; }
            public string Country { get; set; }
            public string Product { get; set; }
            public bool InStock { get; set; }
            public Int16 Count { get; set; }
            public double Price { get; set; }
        }
    
        public partial class Test : System.Web.UI.Page
        {
            protected DataTable dtStoreInfo = new DataTable();
            protected List<MyStoreObject> MyStoreObjects = new List<MyStoreObject>();
    
            //protected
            protected void Page_Init(object sender, EventArgs e)
            {
                dtStoreInfo.Columns.AddRange(new DataColumn[] {
                    new DataColumn("StoreID", typeof(int)),
                    new DataColumn("StoreName", typeof(string)),
                    new DataColumn("Country", typeof(string)),
                    new DataColumn("Product", typeof(string)),
                    new DataColumn("InStock", typeof(bool)),
                    new DataColumn("Count", typeof(Int16)),
                    new DataColumn("Price", typeof(double))
                });
    
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    FillDatasource();
                    TransformDataSourceToObjects();                
    
                    // here's all the things
                    GridView1.DataSource = MyStoreObjects;
                    GridView1.DataBind();
    
                    // we need to break this down into a multi-column layout; the store name, id, and country in one section
                    // then additional sections per product that have the prod as the header, the in-stock, count, and price in body
                    // you can create whatever controls you need to display this information
    
                    var MyStoreObjects_Stores = MyStoreObjects.Select(x => new { x.StoreID, x.StoreName, x.Country }).Distinct();
                    var MyStoreObjects_Products = MyStoreObjects.Select(x => x.Product).Distinct();
    
                    Table displayTable = new Table();
                    TableRow tRow = new TableRow();
                    TableCell tCell = new TableCell();
                    tRow.Cells.Add(tCell);
                    displayTable.Rows.Add(tRow);
    
                    GridView oGridViewMain = new GridView();
                    oGridViewMain.DataSource = MyStoreObjects_Stores;
                    oGridViewMain.DataBind();
                    tCell.Controls.Add(oGridViewMain);
                    
                    foreach (var product in MyStoreObjects_Products)
                    {
                        var resultByProd = MyStoreObjects.Where(x => x.Product == product);
    
                        GridView gvProduct = new GridView();
                        gvProduct.DataSource = resultByProd;
                        gvProduct.DataBind();
                        TableCell tCellProd = new TableCell();
                        tCellProd.Controls.Add(gvProduct);
                        tRow.Cells.Add(tCellProd);
                    }
    
                    container.Controls.Add(displayTable);
                }
            }
    
            private void FillDatasource()
            {
                // assume this comes from a database query eventually, maybe from a dataadapter fill or whatever
                dtStoreInfo.Rows.Add(new object[] { 1, "Tesco", "UK", "Soap", true, 10, 2.99 });
                dtStoreInfo.Rows.Add(new object[] { 2, "Asda", "UK", "Soap", false, 0, 0.00 });
                dtStoreInfo.Rows.Add(new object[] { 3, "Aldi", "UK", "Soap", true, 15, 2.98 });
                dtStoreInfo.Rows.Add(new object[] { 1, "Tesco", "UK", "Cheese", true, 10, 4.72 });
                dtStoreInfo.Rows.Add(new object[] { 2, "Asda", "UK", "Cheese", false, 0, 0.00 });
                dtStoreInfo.Rows.Add(new object[] { 3, "Aldi", "UK", "Cheese", true, 15, 3.57 });
    
            }
    
            private void TransformDataSourceToObjects()
            {
                // this would ideally come from LINQ to SQL or another ORM, presented simplified here for demo only
                foreach (DataRow row in dtStoreInfo.Rows)
                {
                    MyStoreObjects.Add(new MyStoreObject()
                    {
                        StoreID = (Int32)row["StoreID"],
                        StoreName = (string)row["StoreName"],
                        Country = (string)row["Country"],
                        Product = (string)row["Product"],
                        InStock = (bool)row["InStock"],
                        Count = (Int16)row["Count"],
                        Price = (double)row["Price"]
                    });
                }
            }
        }
    }
