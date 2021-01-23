     using System.Collections.Generic;
     namespace WebApplication3
                {
    public partial class WebForm1 : System.Web.UI.Page
    {
        GridView GV = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Dummy datasource
            ArrayList names = new ArrayList() { };
            names.Add(new Person { Age = 29, Name = "Abide", Surname = "Masaraure" });
            names.Add(new Person { Age = 28, Name = "Lopi", Surname = "Sewa" });
            Create_GV(names);
          
        }
        protected void Create_GV(ArrayList BetTable)
        {
            if (GV == null)
            {
                GV = new GridView
                {
                    DataSource = BetTable,
                    HorizontalAlign = System.Web.UI.WebControls.HorizontalAlign.Center
                };
                GV.DataSource = BetTable;
                GV.Columns.Add(new ButtonField { Text = "+", CommandName = "Select" });
                GV.RowCommand += GV_RowCommand;
                GV.RowCreated += GV_RowCreated;
                GV.DataBind();
                GV.HeaderRow.Cells[BetTable.Capacity-1].Text = "Přidat";
                form1.Controls.Add(GV);
            }
        }
      
        protected void GV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
              //this will fire
        }
        protected void GV_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridViewRow row = e.Row;
            // Intitialize TableCell list
            List<TableCell> columns = new List<TableCell>();
            foreach (DataControlField column in GV.Columns)
            {
                //Get the first Cell /Column
                TableCell cell = row.Cells[0];
                // Then Remove it after
                row.Cells.Remove(cell);
                //And Add it to the List Collections
                columns.Add(cell);
            }
            // Add cells
            row.Cells.AddRange(columns.ToArray());
        }
       
          }
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
            }
