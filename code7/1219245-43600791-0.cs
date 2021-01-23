	public static List<DeviceCompactInfo> GetPnPDeviceInfo(string captionLikeCondition)
	{
		var selectQuery = "SELECT Caption, Description, Manufacturer, SystemName, DeviceID From Win32_PnPEntity ";
		var query = string.Format("{0} WHERE ConfigManagerErrorCode = 0 and Caption like '{1}' ", selectQuery, captionLikeCondition);
		var searcher = new System.Management.ManagementObjectSearcher(query);
		var pnpList = searcher.Get().Cast<System.Management.ManagementBaseObject>()
			.Select(x => new DeviceCompactInfo
			{
				Name = Convert.ToString(x["Caption"]),
				Description = Convert.ToString(x["Description"]),
				Manufacturer = Convert.ToString(x["Manufacturer"]),
				SystemName = Convert.ToString(x["SystemName"]),
				DeviceID = Convert.ToString(x["DeviceID"]),
			})
			.ToList();
		return pnpList;
	}
	[System.Diagnostics.DebuggerDisplay("Name:{Name}, Description:{Description}, Manufacturer:{Manufacturer}, SystemName:{SystemName}, DeviceID:{DeviceID}", Name = "DeviceCompactInfo")]
	public class DeviceCompactInfo
	{
		public string Name
		{
			get;
			set;
		}
		public string Description
		{
			get;
			set;
		}
		public string Manufacturer
		{
			get;
			set;
		}
		public string SystemName
		{
			get;
			set;
		}
		public string DeviceID
		{
			get;
			set;
		}
	}
