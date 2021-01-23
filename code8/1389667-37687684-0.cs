			var dialog = new OpenFileDialog();
			dialog.ShowDialog();
			var path = dialog.FileName;
			using (var managementObject = new ManagementObject())
			{
				managementObject.Path = new ManagementPath($"Win32_LogicalDisk='{path.Substring(0,2)}'");
				var driveType = (DriveType)(uint)managementObject["DriveType"];
				var networkPath = Convert.ToString(managementObject["ProviderName"]);
				
				if (driveType == DriveType.Network)
				{
					MessageBox.Show(path.Replace(path.Substring(0, 3), networkPath));
				}
			}
			MessageBox.Show(path);
