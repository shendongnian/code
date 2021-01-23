    protected void Page_Load(object sender, EventArgs e)
        {
            string SelectID = "ddlTest";
            string Options = "<option value='volvo'>Volvo</option>"; 
            DivPlant.Controls.Add(new LiteralControl("<select name='ddlName' id='" + SelectID + "'>" + Options + "</select>"));
           
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            lblSelection.Text = Request.Form["ddlName"];
        }
