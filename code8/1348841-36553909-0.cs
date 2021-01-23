    public void getpermission()
    {
        if(HttpContext.Current.User.Identity.IsAuthenticated)
        {
            string username=HttpContext.Current.User.Identity.Name;
            System.Data.DataTable dt = DML.gettable("select l.`btn1`, l.`btn2`, l.`btn3`, l.`btn4`, l.`btn5`, l.`btn6`, l.`btn7`, l.`btn8`, l.`btn9`, l.`btn10`, l.`btn11`, l.`btn12`, l.`btn13`, l.`btn14`, l.`btn15`, l.`btn16` from menu l right join login m on m.id=l.Userid where m.userName='" + username + "'");
            if (dt.Rows.Count > 0)
            {
                for (int i = 2; i < dt.Columns.Count; i++)
                {
                    int status=Convert.ToInt32(dt.Rows[0][i].ToString());
                    if (status==1)
                    {
                        string columnname="d"+dt.Columns[i].ToString();
                        HiddenFieldID.Value = HiddenField.Value + columnname + ",";
                        ClientScript.RegisterStartupScript(this.GetType(), "getid", "hideid()", true);
                    }
    
                }
                //remove the last comma
                HiddenField.Value = string.Remove(HiddenField.Value.Length - 1);
            }
    
    
        }
