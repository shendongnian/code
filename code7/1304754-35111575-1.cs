    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["Action"] != null && Request.QueryString["Action"].ToString() == "FindControl")
        {
             HttpContext.Current.Response.Write(ControlsList(this));
             HttpContext.Current.Response.End();
        }
    }
    public void ControlsList(Control parent)
        {
            string ans = "";
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox || c is Button || c is DropDownList || c is CheckBox || c is RadioButton || c is CheckBoxList || c is RadioButtonList || c is ImageButton || c is LinkButton)
                {
                    if(c.ID != null && c.ID != "")
                    ans +=c.ID + "," + ((System.Reflection.MemberInfo)(c.GetType().UnderlyingSystemType)).Name + ";";
                }
                ans += ControlsList(c);
            }
            return ans;
        }
