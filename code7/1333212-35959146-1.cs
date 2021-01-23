  	foreach (var pValue in management.GetInstances().Cast<ManagementObject>()
		.Select(managementObject => managementObject.Properties.Cast<PropertyData>()
		.FirstOrDefault(p => p.Name == "CSName"))
		.Where(pValue => pValue != null))
	{
		TxtBody.Text += "<br><font color = red>" + pValue.Name + ": " + pValue.Value + "</font>";
		break;
	}
