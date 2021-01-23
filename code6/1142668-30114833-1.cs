	public static bool EmptyFolderTransactionaly(string folder)
	{
		var directoryInfo = new DirectoryInfo(folder);
		var tmpDir = Directory.CreateDirectory(Path.Combine(folder, Path.GetFileName(Path.GetTempFileName())));
		try
		{
			foreach (var e in directoryInfo.EnumerateFiles())
			{
				e.MoveTo(Path.Combine(tmpDir.FullName, e.Name));
			}
			foreach (var e in directoryInfo.EnumerateDirectories().Where(e => e.Name!=tmpDir.Name))
			{
				e.MoveTo(Path.Combine(tmpDir.FullName, e.Name));
			}
			return true;
		}
		catch
		{
			MessageBox.Show("Failed to remove files. Manually empty the folder and try again.", "Error");
			foreach (var e in tmpDir.EnumerateDirectories())
			{
				e.MoveTo(Path.Combine(directoryInfo.FullName, e.Name));
			}
			foreach (var e in tmpDir.EnumerateFiles())
			{
				e.MoveTo(Path.Combine(directoryInfo.FullName, e.Name));
			}
			return false;
		}
		finally
		{
			tmpDir.Delete(true);
		}
	}
