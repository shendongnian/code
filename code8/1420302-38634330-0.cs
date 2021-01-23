    for (int i = 0; i < filterAppointmentsToChangeLocation.RecordCount; i++)
    {
	    int selrow = 1
	    var calitm = filterAppointmentsToChangeLocation.data[selrow].GetOlAppointment();
	    try
	    {
            calitm.UserProperties["location"].Value = extracted;
	        calitm.Save();
	    }
	    catch (Exception e)
	    {
		    // save, output or retrhow your exception.
		    System.IO.File.WriteAllText (@"C:\somepath\error.txt", e.Message);
	    }
	    Marshal.ReleaseComObject(calitm);
    }
