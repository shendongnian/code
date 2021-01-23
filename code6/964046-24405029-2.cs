    int iWantedStringLength = 20;
    // Edited here:
    string sFormatInstruction = "{0,-" + iWantedStringLength.ToString() + "}";
	
    for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColumnCount; j++)
            {
                sw.Write(String.Format(sFormatInstruction, Transfer_2D[i][j]));//write one row separated by columns
                if (j < ColumnCount)
                {
                    sw.Write(";");//use ; as separator between columns
                }
            }
            if (i < RowCount)
            {
                sw.Write("\n");//use \n to separate between rows
            }
        }
