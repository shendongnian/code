    namespace MyNamespace
    {
       public class Default : Page
       {
           IEnumerable<School> dataItems {get;set;}
        
           protected void Page_Load(object sender, EventArgs e)
           {
               dataItems = new School[] { new School() { Name = "School 1" }, new School() { Name = "School 2" }, new School() { Name = null }, new School() { Name = "School 3" } }.AsEnumerable();
               lview.DataSource = dataItems;
               lview.DataBind();
           }
        
           protected void lview_ItemDataBound(object sender, ListViewItemEventArgs e)
           {            
               ListView listview = (ListView)sender;
               ListViewItem row = e.Item;
               School dataItem = (School)e.Item.DataItem;
               if (dataItem.Name == null)
               {
                   row.Visible = false;
               }
           }
       }
       public class School
       {
           public string Name { get; set; }
       }
    }
