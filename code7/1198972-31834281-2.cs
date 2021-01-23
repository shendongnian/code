    try
    {
        if(upload!=null && upload.ContentLength>0)
        {
            fileName = System.IO.Path.GetFileName(upload.FileName);
            imagePath = "/Content/Images/Items/" + fileName;
            upload.SaveAs(Server.MapPath(imagePath));
        }
        else
            imagePath = "/Content/Images/Items/" + "NoImage.jpg";
        productDisplay.ImagePath = imagePath;
        ProductMangementBL balProduct = new ProductMangementBL();
        isSaved = balProduct.AddProduct(productDisplay);
    }
    catch (Exception ex)
    {
        using (StreamWriter writer = new StreamWriter("C:\\log.txt", true))
    	{
    	    writer.WriteLine(ex);
    	}
    }
