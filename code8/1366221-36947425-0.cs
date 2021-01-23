    public static void ExportWithHeader(RadGridView grid, string header)
    {
        try
        {
            string extension = "xls";
            SaveFileDialog dialog = new SaveFileDialog()
            {
                DefaultExt = extension,
                Filter = String.Format("{1} files (*.{0})|*.{0}|All files (*.*)|*.*", extension, "Excel"),
                FilterIndex = 1,
                FileName = header
            };
            if (dialog.ShowDialog() == true)
            {
                using (Stream stream = dialog.OpenFile())
                {
                    MemoryStream ms = new MemoryStream();
                    grid.Export(
                        ms,
                        new GridViewExportOptions()
                        {
                            Format = ExportFormat.ExcelML,
                            ShowColumnHeaders = true,
                            ShowColumnFooters = true,
                            ShowGroupFooters = false,
                        });
                    ms.Seek(0, SeekOrigin.Begin);
                    header = String.Format(
                        "<Row><Cell  ss:Index='1'><Data ss:Type='String'>{0}</Data></Cell></Row>", header);
                    StreamReader sr = new StreamReader(ms);
                    string msStr = sr.ReadToEnd();
                    msStr = msStr.Insert(msStr.IndexOf("<Row>"), header);                    
                    stream.Write(Encoding.UTF8.GetBytes(msStr), 0, msStr.Length);
                }
                Process.Start(dialog.FileName);
            }
        }
        catch
        {
            Notification.Error("Process Busy", "Please exit excel instance.");
        }
    }
