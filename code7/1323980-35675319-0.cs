    File.WriteAllBytes(Application.persistentDataPath, bytes);
	public static void CacheItem(string url, Mesh mesh)
	{
		string path = Path.Combine(Application.persistentDataPath, url);
        byte [] bytes = MeshSerializer.WriteMesh(mesh, true);
		File.WriteAllBytes(path, bytes);
	}
