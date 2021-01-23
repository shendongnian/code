    using System;
    using System.Data;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml;
    
    namespace WebApplication1
    {
        public partial class _Default : Page
        {
            DataTableCollection tables = null;
    
            protected void Page_Load(object sender, EventArgs e)
            {
                XmlDocument doc = new XmlDocument();
                DataSet ds = new DataSet();
                ds.ReadXml("C:\\dev\\books.xml");
    
                //ds.Tables[0] is the books table
                //ds.Tables[1] is the authors table
                // When reading xml into a DataSet object, the data is normalized (think SQL-like)
                myGridView.DataSource = ds.Tables[0];
                tables = ds.Tables;
                myGridView.DataBind();
            }
    
            protected void myGridView_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    Repeater repeater = (Repeater)e.Row.FindControl("myRepeater");
    
                    // Because our data is now in tables, we need to join the tables based on the book_Id identifier
                    // The columns named book_Id in table 0 and table 1 were both created for us automatically to link up the data
                    // when we read the xml into the DataSet object.
                    var authors = tables[1].AsEnumerable().Where(x => x["book_Id"] as int? == e.Row.DataItemIndex).AsDataView();
    
                    repeater.DataSource = authors;
                    repeater.DataBind();
                }
            }
    
            protected void myRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
    
            }
        }
    }
