     protected void multiuser_SelectedIndexChanged(object sender, EventArgs e)
     {
    cookieIdDTES = new HttpCookie("idDTES");
    cookieIdDTES.Expires = DateTime.Now.AddHours(8);
    cookieIdDTES["Name"] = multiuser.SelectedValue.ToString();
    Response.Write("Value of DDL: " + multiuser.SelectedValue.ToString() + "<br />");
    Response.Write("Value of Cookie : " + cookieIdDTES.Value + "<br />");
    Response.Cookies.Add(cookieIdDTES);
    Response.Write("Print request cookie : " + cookieIdDTES["Name"]);
    Response.End();
    }
