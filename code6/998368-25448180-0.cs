    if (ProductDetails.ProductBackPicFilePath != "")
    {
         byte[] fileContents = System.IO.File.ReadAllBytes(ProductDetails.ProductBackPicFilePath);
    
         using (System.IO.MemoryStream ms = new System.IO.MemoryStream(fileContents))
         {
              mProdButList[i].BackgroundImage = Image.FromStream(ms);                               
         }
         mProdButList[i].BackgroundImageLayout = ImageLayout.Stretch;
    }
