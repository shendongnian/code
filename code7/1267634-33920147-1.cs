    private void btnXlsConvert_Click()
    {
        StreamReader s = new StreamReader(
            @"C:\Users\AniKet\Desktop\Project Work\SpatioTemporalFeature\blah blah");
        string line = "";
        int row = 1;
        while ((line = s.ReadLine()) != null) {
            sheet.Cells[row, 1].Value = 1;
            int col = 2;
            string[] arr = line.Split(' ');  // this was changed
            int value = arr.Length;
            for (int i = 0; i < value; i++)
            {
                sheet.Cells[row, col++].Value = arr[i];
            }
            row++;
        }
    }
