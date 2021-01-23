    private void button1_Click(object sender, EventArgs e)
        {
            byte[] fileByteArray = global::YourProjectNameSpace.Properties.Resources.ExcelFileName;
    
            if (ByteArrayToFile(@"C:\Temp\file.xlsx", fileByteArray))
            {
                //File was saved properly
            }
            else
            {
                //There was an error saving the file
            }
        }
