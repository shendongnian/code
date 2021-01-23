    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI.WebControls;
    namespace Web
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            DataClasses1DataContext dc = new DataClasses1DataContext();
            public List<CameraTable> CameraListBox;
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    CameraListBox = (from x in dc.CameraTables
                                     select x).ToList();
                    var itemsToAdd = CameraListBox
                        .Select(c => GetListItem(c))
                        .ToArray();
                    ListBox1.Items.AddRange(itemsToAdd);
                }
            }
            public ListItem GetListItem(CameraTable item)
            {
                var listItem = new ListItem(item.CameraName, item.IPAddress);
                if (string.IsNullOrEmpty(item.GroupName) == false)
                    listItem.Attributes.Add("data-category", item.GroupName);
                return listItem;
            }
        }
        public class DataClasses1DataContext
        {
            public IQueryable<CameraTable> CameraTables
            {
                get
                {
                    return new List<CameraTable>()
                    {
                        new CameraTable("Back Hallway", "1.1.1.1", "Floor 1"),
                        new CameraTable("Bedroom 1", "2.2.2.2", "Floor 1"),
                        new CameraTable("Bedroom 2", "3.3.3.3", "Floor 2"),
                    }.AsQueryable();
                }
            }
        }
        public class CameraTable
        {
            public string CameraName { get; set; }
            public string IPAddress { get; set; }
            public string GroupName { get; set; }
            public CameraTable(string name, string ip, string group)
            {
                this.CameraName = name;
                this.IPAddress = ip;
                this.GroupName = group;
            }
        }
    }
