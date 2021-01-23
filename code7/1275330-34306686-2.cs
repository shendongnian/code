    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    
    namespace DataGridViewBounds
    {
      public partial class _Default : Page
      {
        public enum DataType
        {
          Text,
          YesNo
        }
    
        public class IndexedItem
        {
          public string Name
          { get; set; }
          public int ID
          { get; set; }
          public string strID
          { get { return ID.ToString(); } }
        }
    
        protected void Page_Load (object sender, EventArgs e)
        {
    
          if (!IsPostBack)
          {
            Bind();
          }
    
          for (int i = 0; i < dg.Items.Count; ++i)
          {
            bool ShowText = ((DropDownList)dg.Items[i].Cells[0].Controls[1]).SelectedValue.Equals("text");
            ((DropDownList)dg.Items[i].Cells[1].Controls[1]).Visible = !ShowText;
            ((TextBox)dg.Items[i].Cells[1].Controls[3]).Visible = ShowText;
          }
    
        }
    
        private void Bind ()
        {
          DataTable ParameterTable = new DataTable("ParameterTable");
          ParameterTable.Columns.Add("", typeof(string));
          ParameterTable.Columns.Add("Type", typeof(DataType));
          ParameterTable.Columns.Add("Value", typeof(string));
    
          List<ListItem> YesNoList = new List<ListItem>();    // Should be ListItem, not IndexedItem
          YesNoList.Add(new ListItem("Yes", "1"));
          YesNoList.Add(new ListItem("No", "0"));
    
          DataRow row = ParameterTable.NewRow();
          row["Type"] = DataType.Text;
          row["Value"] = "Some text";
    
          DataRow row2 = ParameterTable.NewRow();
          ParameterTable.Rows.Add(row);
          row2["Type"] = DataType.YesNo;
          row2["Value"] = "false";
          ParameterTable.Rows.Add(row2);
    
          dg.DataSource = ParameterTable;
          dg.DataBind();
          dg.ShowHeader = true;
          dg.Visible = true;
    
          for (int i = 0; i < dg.Items.Count; ++i)
          { // Showing 2 ways to bind the DropDownList items
            ((DropDownList)dg.Items[i].Cells[0].Controls[1]).Items.Add(new ListItem("Text", "text"));
            ((DropDownList)dg.Items[i].Cells[0].Controls[1]).Items.Add(new ListItem("Yes/No", "bool"));
    
            ((DropDownList)dg.Items[i].Cells[1].Controls[1]).DataSource = YesNoList;
            ((DropDownList)dg.Items[i].Cells[1].Controls[1]).DataBind();
          }
        }
      }
    }
