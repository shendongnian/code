	if (!riflesRadio.Checked && !smgsRadio.Checked && !heavysRadio.Checked)
	// then execute below
	{
		if (secondaryList.Enabled == false)
		{
			secondary = "";
			secondarycost = 0;
		}
		if (heavyList.Enabled == false)
		{
			heavys = "";
			heavycost = 0;
		}
		if (primaryList.Enabled == false)
		{
			rifles = "";
			riflecost = 0;
		}
		if (smgList.Enabled == false)
		{
			smgs = "";
			smgcost = 0;
		}
	}
	//up to here
