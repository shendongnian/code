        string realPath = Application.persistentDataPath + "/PATH/" + fileName;
		if (!System.IO.File.Exists(realPath))
		{
			if (!System.IO.Directory.Exists(Application.persistentDataPath + "/PATH/"))
			{
				System.IO.Directory.CreateDirectory(Application.persistentDataPath + "/PATH/");
			}
			WWW reader = new WWW(Application.streamingAssetsPath + "/PATH/" + realPath);
			while ( ! reader.isDone) {}
			System.IO.File.WriteAllBytes(realPath, reader.bytes);
		}
		Application.OpenURL(realPath);
