    using System.IO.Compression; // Had to add an assembly for this
    using Novacode;
    
    // Have to specify to remove ambiguous error from Novacode
    Dictionary<string, System.Drawing.Image> images = new Dictionary<string, System.Drawing.Image>();
    
    void LoadTree()
    {
    	// In case of previous exception
    	if(File.Exists("Images.zip")) { File.Delete("Images.zip"); }
    
    	// Allow the file to be open while parsing
    	using(FileStream stream = File.Open("Images.docx", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
    	{
    		using(DocX doc = DocX.Load(stream))
    		{
    			// Work rest of document
    
    			// Still parse here to get the names of the images
    			// Might have to drag and drop images into the file, rather than insert through Word
    			foreach(Picture pic in doc.Pictures)
    			{
    				string name = pic.Description;
    
    				if(null == name) { continue; }
    
    				name = name.Substring(name.LastIndexOf("\\") + 1);
    				name = name.Substring(0, name.Length - 4);
    
    				images[name] = null;
    			}
    
    			// Save while still open
    			doc.SaveAs("Images.zip");
    		}
    	}
    
    	// Use temp zip directory to extract images
    	using(ZipArchive zip = ZipFile.OpenRead("Images.zip"))
    	{
    		// Gather all image names, in order
    		string[] keys = images.Keys.OrderByDescending(o => o).ToArray();
    
    		for(int i = 1; ; i++)
    		{
    			// Also had to add an assembly for ZipArchiveEntry
    			ZipArchiveEntry entry = zip.GetEntry(String.Format("word/media/image{0}.png", i));
    
    			if(null == entry) { break; }
    
    			Stream stream = entry.Open();
    
    			images[keys[i - 1]] = new Bitmap(stream);
    		}
    	}
    
    	// Remove temp directory
    	File.Delete("Images.zip");
    }
