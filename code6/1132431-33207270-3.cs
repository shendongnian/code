    string MilSystemDet = "";
	MilSystemDet = Environment.GetEnvironmentVariable("Mil_Path");
	if (MilSystemDet != null)
	{ 
		string dcfFilePath = "";
		FileDialog OpenFile = new OpenFileDialog();
		OpenFile.Filter = "File Formats(*.dcf)|*.DCF;";
		if (OpenFile.ShowDialog() == DialogResult.OK)
		{ 
			dcfFilePath = OpenFile.FileName;
			MIL.MdigAlloc(MilSystem, MIL.M_DEFAULT, dcfFilePath, MIL.M_DEFAULT, ref MilDigitizer);
			MIL.MbufAlloc2d(
				MilSystem, 
				MIL.MdigInquire(MilDigitizer, MIL.M_SIZE_X, MIL.M_NULL), 
				MIL.MdigInquire(MilDigitizer, MIL.M_SIZE_Y, MIL.M_NULL), 
				8 + MIL.M_UNSIGNED, 
				MIL.M_IMAGE + MIL.M_DISP + MIL.M_GRAB, 
				ref MilImage);
            MIL.MdispAlloc(MilSystem, MIL.M_DEFAULT, ("M_DEFAULT"), MIL.M_DEFAULT, ref MilDisplay);
			MIL.MdigHalt(MilDigitizer);
		}
	}
