	public int IsExists() 
	{
		int returnInt =0;
		foreach (GridViewRow row in gvSerials.Rows) 
		{
			using (SqlConnection con = new SqlConnection(strConnString)) 
			{
				using (SqlCommand cmd = new SqlCommand("usp_InsertReceiptSerials", con)) 
				{
                // /.../
				if whatever your testing is true:
				returnInt = 1;
                or
                return returnInt;
				or
				return 1;
                or wait until the end of the method if you want to add more stuff.
				}
			}
		}
        // Do any more stuff here.
		return returnInt();
        // Nothing beyond here is executed.
   
	}
