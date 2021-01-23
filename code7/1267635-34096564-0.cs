    private void btnXlsConvert_Click()
    {
        
        StreamReader stream = new StreamReader(file_path);
        string line;
        int rowIndex = 1;
        while ((line = stream.ReadLine()) != null)
        {
            string[] values = line.Split(' ');
            sheet.Cells[rowIndex, 1].Value = 1;
            for (int columnIndex = 2; columnIndex < values.Length + 2;columnIndex++)
            {
                sheet.Cells[rowIndex, columnIndex].Value = values[columnIndex - 2];
            }
            rowIndex++;
        }
        stream.Close();
    
        try
        {
            if (File.Exists(@"C:\Users\Timmo\Desktop\testdata.xls"))
                File.Delete(@"C:\Users\Timmo\Desktop\testdata.xls");
            wb.SaveAs(@"C:\Users\AniKet\Desktop\testdata.xls");
        }
        catch(Exception ex)
        {
             MessageBox.Show(ex.Message);
        }
    }
