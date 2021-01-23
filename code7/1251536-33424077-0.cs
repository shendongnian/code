    if (!IsPostBack)
    {
        listener = new UdpClient(listenPort);
        Session["listener"] = listener;
    }
    else
    {
        listener = (UdpClient)Session["listener"];
    }
