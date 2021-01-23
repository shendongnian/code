    int dataSize = 0;
    foreach(DataRow dr in Dataset1.Tables[0].Rows) 
	{
		int rowSize = 0;
		for (int i = 0; i < Dataset1.Tables[0].Columns.Count; i++)
        {
        	rowSize += System.Runtime.InteropServices.Marshal.SizeOf(dr[i]);
        }
        dataSize += rowSize;
    }
