    private void scan(ManagementScope scope, string drive)
    {
	var disk = scope.Device(drive).GetEnumerator();
	if (!disk.MoveNext())
	{
		Add(String.Format("{0} drive not found",drive),0);
		return;
	}
	Add(drive, disk.Current.Size() - disk.Current.FreeSpace());
	// iterate over root Folders
	foreach (var folder in scope.Folder(drive))
	{
		ulong totalsize = 0;
		try
		{
			// iterate over the files
			foreach (var file in scope.File(
						drive,
						folder.Path(),
						folder.FileName()))
			{
				totalsize += file.FileSize();
			}
			// iterate over all subfolders
			foreach (var subfolder in scope.SubFolder(drive
						, folder.Path()
						, folder.FileName()))
			{
				// iterate over files within a folder
				foreach (var file in scope.File(
						drive,
						subfolder.Path(),
						subfolder.FileName()))
				{
					totalsize += file.FileSize();
				}
			}
		}
		catch (Exception exp)
		{
			Debug.WriteLine(exp.Message);
		}
		Add(folder.Name(), totalsize);	
	}
    }
