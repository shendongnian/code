     public  Image GetmageFromStream(string path)
    {
	  using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read)) {
		var img = Image.FromStream(fs);
		return img;
            	}
    }
