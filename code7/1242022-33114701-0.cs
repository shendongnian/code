    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class WebForm1 : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                DataTable theTable = new DataTable();
                theTable.Columns.Add("Names", typeof(string));
                theTable.Rows.Add("Name1");
                theTable.Rows.Add("Name2");
                theTable.Rows.Add("Name3");
    
                for (int i = 0; i < theTable.Rows.Count; i++ )
                {
                    string theValue = theTable.Rows[i].ItemArray[0].ToString();
                    DropDownList1.Items.Add(theValue);
                }
                
            }
        }
    }
