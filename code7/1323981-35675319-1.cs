    public static Mesh GetCacheItem(string url)
	{
		string path = Path.Combine(Application.persistentDataPath, url);
		if(File.Exists(path) == true)
		{
			byte [] bytes = File.ReadAllBytes(path);
			return MeshSerialize.ReadMesh(bytes);
		}
		return null;
	}
