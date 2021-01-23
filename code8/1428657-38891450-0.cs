     protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               string Image2Display1 = GetRandomImageAdult();
               RandomImg1.ImageUrl = Path.Combine("~/adults", Image2Display1);
                i++;
    
         //// rest of the code
