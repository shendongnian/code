     public void img_click(object s, EventArgs e)
        {
            ImageButton img = new ImageButton();
            img = s as ImageButton;
            img2.ImageUrl = img.ImageUrl;
        }
    you need to get the image button that was clicked, which is really your only problem.
