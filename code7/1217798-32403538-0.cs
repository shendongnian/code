    string tableName = "myTable";
    string delimeter = " ";
    string line = "col1 col2 col3 col4" + Environment.NewLine;
    int intIndexofCRLF = line.IndexOf(Environment.NewLine);
    string fileHeader = line.Substring(0, intIndexofCRLF);
    string[] fileHeaderSegments = fileHeader.Split(new string[] { delimeter }, StringSplitOptions.None);
    StringBuilder sb = new StringBuilder(string.Format("CREATE TABLE {0} (", tableName));
    for(int i=0;i<fileHeaderSegments.Length;i++)
    {
        if (i!=0)
        {
            sb.Append(",");
        }
        sb.Append(fileHeaderSegments[i]);
        sb.Append(" varchar(255)");
    }
    sb.Append(");");
    Console.WriteLine(sb.ToString());
    Console.ReadKey();
