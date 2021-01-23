    if (filename.CreationTime < dt.AddMonths(-1))
    {
    	try
    	{
            if (!filename.Exists)
    			throw new Exception("File does not exist");
    
            filename.Delete();
            WriteLine("{0} was deleted successfully.", destination_path + "\\" + filename);
        }
        catch (Exception ex)
        {
    		WriteLine("The deletion process failed: {0}", ex.Message);
        }
    }
