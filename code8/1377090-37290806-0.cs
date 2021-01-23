    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;
    
    namespace WebApplication6
    {
        public partial class DataListAndGrid : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                var dt = new DataTable();
                dt.Columns.Add(new System.Data.DataColumn("ID", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("Day", typeof(String)));
    
                AddRow("0", "MONDAY", dt);
                AddRow("1", "TUESDAY", dt);
                AddRow("2", "WEDNESDAY", dt);
                AddRow("3", "THURSDAY", dt);
                AddRow("4", "FRIDAY", dt);
                AddRow("5", "SATURDAY", dt);
                AddRow("6", "SUNDAY", dt);
    
                daysOfWeek.DataSource = dt;
                daysOfWeek.DataBind();
            }
    
            private void AddRow(string id, string day, DataTable dt)
            {
                DataRow row;
                row = dt.NewRow();
                row[0] = id;
                row[1] = day;
                dt.Rows.Add(row);
            }
    
            private void BindGrid(GridView gv, int id)
            {
                gv.DataSource = this.GetRegisters(id);
                gv.DataBind();
            }
    
            protected void daysOfWeek_ItemDataBound(object sender, DataListItemEventArgs e)
            {
                object dataKey = daysOfWeek.DataKeys[e.Item.ItemIndex];
    
                int key = Convert.ToInt32(dataKey);
    
                GridView gridResponses = (GridView)e.Item.FindControl("gvResponses");
                BindGrid(gridResponses, key);
            }
    
            public List<Register> GetRegisters(int id)
            {
                List<Register> registers = new List<Register>();
                registers.Add(new Register() { DayID = 0, FirstName = "Monday Name 1", LastName = "Monday Surname 1" });
                registers.Add(new Register() { DayID = 0, FirstName = "Monday Name 2", LastName = "Monday Surname 2" });
                registers.Add(new Register() { DayID = 1, FirstName = "Tuesday Name 1", LastName = "Tuesday Surname 1" });
                registers.Add(new Register() { DayID = 1, FirstName = "Tuesday Name 1", LastName = "Tuesday Surname 2" });
    
                return registers.Where(r => r.DayID == id).ToList();
            }
        }
    
        public class Register
        {
            public int DayID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
    }
