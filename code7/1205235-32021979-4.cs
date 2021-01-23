    for (int i = 0; i <= 19; i++)
    {
        var pictureBox = (PictureBox) Form2.ActiveForm.Controls.Find("PB" + i, true)[0];
        var productInfo = new ProductInfo
        {
            //This class is not mentioned into the question so I set example properties here eg.
           ImageName = "MyImage1.png",
           ImagePath = "C:\\Images\\"
           ...
        };
        pictureBox.Tag = productInfo;
        pictureBox.Click += (sender, args) =>
        {            
            msgShow((ProductInfo)((sender as PictureBox).Tag));
        };
    }
