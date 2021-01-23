	using (StreamReader reader = new StreamReader(Application.persistentDataPath+"/"+"CHARVER.BIN"))
	{
		JSONNode characterImages;
		string json = reader.ReadToEnd();
		
		if(!string.IsNullOrEmpty(json))
		{
			characterImages = JSON.Parse(json);
			//test the image file inside
			Texture2D loadedImage = new Texture2D(1,1,TextureFormat.ARGB32,false);
			
			if(characterImages.Keys.Contains("Characters")
				&& characterImages["Characters"].Count() > 0
				&& characterImages["Characters"][0].Keys.Contains("texture"))
			{
				if(loadedImage.LoadImage(File.ReadAllBytes(Application.persistentDataPath + characterImages["Characters"][0]["texture"])))
					return;
			}
		}
		ThrowBackToLogin("No image file was found.");
	}
