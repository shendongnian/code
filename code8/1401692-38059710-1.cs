     protected void lnkEditUpdate_Click(object sender, EventArgs e)
            {
               LinkButton linkEdit =  (LinkButton)sender; // Point the particular row LinkButton clicked
               GridViewRow row = (GridViewRow)linkEdit.NameingContainer;// Fetch the Row
               Employee newe = new Employee();
               newe.ID = int.Parse((gvEmployee.Rows[row.RowIndex].Cells[1]).Text);
               newe.Name = (gvEmployee.Rows[row.RowIndex].Cells[2]).Text;
               newe.Salary = (gvEmployee.Rows[row.RowIndex].Cells[3]).Text;
               Session["Update"] = newe;
               Response.Redirect("~/EditUpdateEmployee.aspx");
            }
