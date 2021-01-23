    public static void StoreCacheSprite(string url, Sprite sprite)
	{
        if(sprite == null || string.IsNullOrEmpty(url) == true) { return; }
        SpriteRenderer spRend = sprite.GetComponent<SpriteRenderer>();
		Texture2D tex = spRend.material.mainTexture;
        byte[] bytes = tex.EncodeToPNG();
        string path = Path.Combine(Application.persistentDataPath, url);
		File.WriteAllBytes(Application.persistentDataPath, bytes);
	}
    public static Sprite GetCacheSprite(string url)
	{
        if( string.IsNullOrEmpty(url) == true) { return; }
        string path = Path.Combine(Application.persistentDataPath, url);
        if(File.Exists(path) == true)
		{
			bytes = File.ReadAllBytes(path);
            Texture2D texture = new Texture2D(4, 4, TextureFormat.RGBA32, false);
			texture.LoadImage(bytes);
            Sprite sp = Sprite.Create(texture, new Rect(0,0 texture.width, texture.height, new Vector2(0.5f,0.5f));
			return sp;
		}
        return null;
	}
