    printDialog = new PrintDialog();
                //when you click on OK
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                //path is your documents to print location 
                ProcessStartInfo info = new ProcessStartInfo(path);
                info.Arguments = "\"" + printDialog.PrinterSettings.PrinterName + "\"";
                info.CreateNoWindow = true;
                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                info.UseShellExecute = true;
                info.Verb = "PrintTo";
                System.Diagnostics.Process.Start(info);
                }
