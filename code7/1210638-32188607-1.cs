    if (PaymentOption == "PayPal")
    {
    NVPAPICaller test = new NVPAPICaller();
    string retMsg = "";
    string token = "";
    string payerId = "";
    token = Session["token"].ToString();
    bool ret = test.GetShippingDetails( token, ref payerId, ref shippingAddress, ref retMsg );
    if (ret)
    {
        Session["payerId"] = payerId;
        Response.Write ( shippingAddress );    
    }
    else
    {
        Response.Redirect("APIError.aspx?" + retMsg);
    }
    }
