    // remove that check if EnableViewState is false
    //if(!Page.IsPostBack)
    {
       LinkButton1.OnClientClick = "ClientClick()";
       Image1.ImageUrl = "~/Images/embed.png";
    }
