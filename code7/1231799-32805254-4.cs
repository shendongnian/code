    //
    // Determine the current recording devices
    //
    MsftDiscMaster2 discMaster = null;
    try
    {
        discMaster = new MsftDiscMaster2();
        if (!discMaster.IsSupportedEnvironment)
            return;
        // Get drives
        foreach (string uniqueRecorderId in discMaster)
        {
            IDiscRecorder2 discRecorder2 = new MsftDiscRecorder2();
            discRecorder2.InitializeDiscRecorder(uniqueRecorderId);
            // Show device mount drive and determine type
            Console.WriteLine("Path: {0} Type: {1}", discRecorder2.VolumePathNames[0], CheckType(discRecorder2));
        }
    }
    catch (COMException ex)
    {
        Console.WriteLine("Error:{0} - Please install IMAPI2", ex.ErrorCode);
    }
    finally
    {
        if (discMaster != null)
            Marshal.ReleaseComObject(discMaster);
    }
