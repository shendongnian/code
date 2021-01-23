    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    
    namespace WebApplication1
    {
        public partial class _Default : Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //Contrived Data table just because I need some data to demonstrate.
                //I assume you are or can acquire a DataTable with your current solution.
                DataTable dt = new DataTable();
                dt.Columns.Add(new DataColumn("UserID", typeof(int)));
                dt.Columns.Add(new DataColumn("UserName", typeof(string)));
                dt.Columns.Add(new DataColumn("Hours", typeof(int)));
    
                DataRow row = dt.NewRow();
                row[0] = 1646;
                row[1] = "Red";
                row[2] = 16;
                dt.Rows.Add(row);
    
                row = dt.NewRow();
                row[0] = 1646;
                row[1] = "Red";
                row[2] = 8;
                dt.Rows.Add(row);
    
                row = dt.NewRow();
                row[0] = 1812;
                row[1] = "Blue";
                row[2] = 6;
                dt.Rows.Add(row);
    
                row = dt.NewRow();
                row[0] = 1812;
                row[1] = "Blue";
                row[2] = 14;
                dt.Rows.Add(row);
    
                //Simplify accumualtor logic by grouping on Userid
                var users = dt.AsEnumerable().GroupBy(u => u[0]);
    
                //For each group (each user id)
                foreach (var item in users)
                {
                    //adds the user hours
                    int accumulator = 0;
                    
                    //For each set or rows in group
                    foreach (var dr in item)
                    {
                        accumulator += int.Parse(dr[2].ToString());
    
                        //Create a table row
                        TableRow tr = new TableRow();
    
                        //Add the cells to the table row
                        TableCell userIdCell = new TableCell();
                        userIdCell.Text = item.Key.ToString();
                        tr.Cells.Add(userIdCell);
    
                        TableCell userNameCell = new TableCell();
                        userNameCell.Text = dr[1].ToString();
                        tr.Cells.Add(userNameCell);
    
                        TableCell hoursCell = new TableCell();
                        hoursCell.Text = dr[2].ToString();
                        tr.Cells.Add(hoursCell);
    
                        //Add the row to the table
                        usertbl.Rows.Add(tr);
                    }
    
                    //create summary row
                    TableRow totalRow = new TableRow();
                    //Skip a cells
                    totalRow.Cells.Add(new TableCell());
                    totalRow.Cells.Add(new TableCell());
                    //total cell
                    TableCell userTotalCell = new TableCell();
                    userTotalCell.Text = accumulator.ToString();
                    totalRow.Cells.Add(userTotalCell);
    
                    //Finally add the row
                    usertbl.Rows.Add(totalRow);
                }
            }
        }
    }
