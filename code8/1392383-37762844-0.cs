    public void BindAlarmlarGrid()
        {
            string CSVFilePathName = pathAlarms;
            string[] Lines = File.ReadAllLines(CSVFilePathName);
            string[] Fields;
            
            for (int i = 0; i < Lines.GetLength(0); i++)
            {
                Fields = Lines[i].Split(new char[] { ',' });
                dgvAlarmlar.Rows.Add(Fields);
            }
        }
