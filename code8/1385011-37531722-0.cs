     <div style="border:1px solid red">
    @using (Html.BeginForm("ActionResult method", "controller"))
    {
    <p>Name:</p>
    {
    if (Session["Name"] == null) 
    {
    Session["Name"] = string.Empty;
    }
    @Html.TextBox("name", Session["Name"].ToString());
    }
    <br /><br />
    <input type="submit" />
    }
    </div>
