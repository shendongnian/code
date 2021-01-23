	public static bool EmptyFolderTransactionaly(string folder)
	{
		var directoryInfo = new DirectoryInfo(folder);
		var tmpDir = Directory.CreateDirectory(Path.Combine(folder, Path.GetTempFileName()));
		try
		{
			foreach (var e in directoryInfo.EnumerateFiles(folder))
			{
				e.MoveTo(tmpDir.FullName);
			}
			foreach (var e in directoryInfo.EnumerateDirectories(folder))
			{
				e.MoveTo(tmpDir.FullName);
			}
			return true;
		}
		catch
		{
			foreach (var e in tmpDir.EnumerateDirectories())
			{
				e.MoveTo(directoryInfo.FullName);
			}
			foreach (var e in tmpDir.EnumerateFiles())
			{
				e.MoveTo(directoryInfo.FullName);
			}
			MessageBox.Show("Failed to remove files. Manually empty the folder and try again.", "Error");
			return false;
		}
		finally
		{
			tmpDir.Delete(true);
		}
	}
