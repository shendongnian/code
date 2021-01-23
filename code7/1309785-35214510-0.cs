	Observable
		.Interval(TimeSpan.FromSeconds(5.0))
		.Subscribe(_ =>
		{
		    foreach (DriveInfo usbname in DriveInfo.GetDrives().Where(usbproperty => usbproperty.DriveType == DriveType.Removable && usbproperty.IsReady))
		    {
		        if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory.ToString() + usbname.VolumeLabel + @"\"))
		        {
		            usbdirectory = new DirectoryInfo(usbname.Name);
		            if (!list_to_copy.Contains(usbdirectory))
		            {
		                list_to_copy.Add(usbdirectory);
		                newfilesfound = true;
		            }
		        }
		    }
		    if (newfilesfound == true)
		    {
		        process_copy();
		        newfilesfound = false;
		    }
		});
