    foreach (string one in urls)
    {
        ImageButton temIBTN = new ImageButton();
        temIBTN.Attributes.Add("Width","265px");
        temIBTN.Attributes.Add("Width", "144px");
        temIBTN.ImageUrl = one;
        temIBTN.Click += setBigPic;
    }
    protected void setBigPic(object sender, ImageClickEventArgs e) 
    {
       img_Big.ImageUrl = ((ImageButton)sender).ImageUrl;
    }
