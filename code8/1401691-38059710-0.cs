     protected void lnkEditUpdate_Click(object sender, EventArgs e)
            {
               LinkButton linkEdit =  (LinkButton)sender; // Point the particular row LinkButton clicked
               GridViewRow row = (GridViewRow)linkEdit.NameingContainer;// Fetch the Row
               Employee newe = new Employee();
               newe.ID = int.Parse(((BoundField)row.FindControl("txtID")).Text);
               newe.Name = ((BoundField)row.FindControl("lblName")).Text;
               newe.Salary = ((BoundField)row.FindControl("Salary")).Text;
               Session["Update"] = newEmployee;
               Response.Redirect("~/EditUpdateEmployee.aspx");
            }
