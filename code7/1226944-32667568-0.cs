    protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (HiddenField1.Value.Trim() == "0")
            {
                return;
            }
            qry = "select count(*) from tbl_payslip_prn_t";
            dt = con.Execute(qry);
            if (dt.Rows.Count > 0)
            {
                ClientScript.RegisterStartupScript(typeof(Page), "exampleScript", "if(confirm(\"Payslip Already Uploaded. Do you want to replace it?\")){ document.getElementById('Button1').click(); }", true);
            }
            else
            {
                //Do Some task
            }
        }  
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Do Some Task    
        }
