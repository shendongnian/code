            DataTable dt = new DataTable();
            dt.Columns.Add("PrinterList");
            foreach (string installedPrinter in PrinterSettings.InstalledPrinters)
            {
                dt.Rows.Add(installedPrinter);
            }
            List<DataRow> Qd = dt.Rows.Cast<DataRow>().ToList();
