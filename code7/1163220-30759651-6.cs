    using (ZipFile zip = new ZipFile()) //encapsulate Step 2 code in this code block
    {
        for (int i = 0; i <= 4; i++)
        {
            DataTable dt = dtCSV[i];
            foreach (DataRow dr in dt.Rows)
            {
                string[] fields = dr.ItemArray.Select(field => field.ToString()).ToArray();
                sb.AppendLine(string.Join("|", fields));
            }
            string textFileName = textFileNameTemplate + (i + 1) + ".txt";
            var textFile = new StreamWriter(textFileName);
            textFile.WriteLine(sb.ToString());
            textFile.Flush();
            textFile.Close();
            zip.AddFile(textFileName, @"\"); //this is new
        }
        zip.Save(Response.OutputStream); //this is also new
    }
    sb.Clear();
    Response.Flush();
    Response.End(); 
