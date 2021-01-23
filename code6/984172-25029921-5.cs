    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApp.DynamicGridViewWithTemplateField
    {
        public partial class WebForm3 : System.Web.UI.Page
        {
    
            protected override void LoadViewState(object savedState)
            {
                base.LoadViewState(savedState);
                CreateGrid();
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    if (!IsPostBack)
                    {
                        CreateGrid();
                        ViewState["foo"] = "foo"; //forcing viewstate
                    }
                }
            }
    
            private static DataTable GetNames()
            {
                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("Name"));
                List<string> names = new List<string>() { "Arun", "Samit", "Jermy", "John" };
                names.ForEach(x =>
                {
                    var row = tbl.NewRow();
                    row[0] = x;
                    tbl.Rows.Add(row);
                });
    
                return tbl;
            }
    
            void CreateGrid()
            {
                GridView gv = new GridView();
                gv.AutoGenerateColumns = false;
                gv.Columns.Add(new BoundField() { 
                    HeaderText="Names",
                    DataField="Name"
                });
                gv.Columns.Add(new TemplateField()
                {
                    ItemTemplate = new TextTemplateField(),
                    HeaderText = "Remarks"
                });
                gv.Columns.Add(new TemplateField()
                {
                    ItemTemplate = new DropDownTemplateField(),
                    HeaderText="Choose option"
                });
    
                gv.Columns.Add(new TemplateField()
                {
                    ItemTemplate = new ButtonTemplateField()                
                });
    
                gv.RowCommand += (sndr, evt) =>
                {
                    if (evt.CommandName == "foo")
                    {
                        Control ctrl = (Control)evt.CommandSource;
                        GridViewRow gvRow = (GridViewRow)ctrl.Parent.Parent;
                        var tbx = gvRow.FindControl("tbx1") as TextBox;
                        tbx.Text = DateTime.Now.ToLongTimeString();
                    }
                };
                gv.DataSource = GetNames();
                gv.DataBind();
                PlaceHolder1.Controls.Add(gv);
            }
        }
    }
