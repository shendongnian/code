    protected void Page_Load(object sender, EventArgs e){
        if(!IsPostBack)
            imgPoke1.ImageUrl = "~/Images/orderedList0.png";
    }
    protected void DropPoke1_SelectedIndexChanged(object sender, EventArgs e)
    {
        imgPoke1.ImageUrl = "~/Images/HomePicture.png";
    }
