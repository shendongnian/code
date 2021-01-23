	SqlDataReader basketReader = User.GetBasket(User.GetUserID(Page.User.Identity.Name));
	if (basketReader.HasRows)
	{
		orderDG.DataKeyField = "ItemCode";
		orderDG.DataSource = basketReader;
		orderDG.DataBind();
		basketReader.Close();
	}
	else
	{
		Response.Redirect("~/Orders.aspx", false);
	}
