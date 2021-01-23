    [DllImport("kernel32.dll")]
    private static extern uint QueryDosDevice(string lpDeviceName, StringBuilder lpTargetPath, int ucchMax);
	public static bool IsTrueCryptVolume(string path, out StringBuilder lpTargetPath)
	{
		bool isTrueCryptVolume = false;
		if (String.IsNullOrWhiteSpace(path))
		{
			throw new ArgumentException("path");
		}
		string pathRoot = Path.GetPathRoot(path);
		if (String.IsNullOrWhiteSpace(pathRoot))
		{
			throw new ArgumentException("path");
		}
		string lpDeviceName = pathRoot.Replace("\\", String.Empty);
		lpTargetPath = new StringBuilder(260);
		if (0 != QueryDosDevice(lpDeviceName, lpTargetPath, lpTargetPath.Capacity))
		{
			isTrueCryptVolume = lpTargetPath.ToString().ToLower().Contains("truecrypt");
		}
		return isTrueCryptVolume;
	}
	static void Main(string[] args)
	{
		StringBuilder targetPath;
		var isTrueCryptVolume = IsTrueCryptVolume("N:\\", out targetPath);
	}
