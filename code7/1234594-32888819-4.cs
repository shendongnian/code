    private void GetStatusCheckboxes()
            {
                Dictionary<string, bool> statusChecked = GetStatusForRow(CVaultDataSource.Band, CVaultGrid.ActiveRow);
                foreach (UltraGridRow row in CVaultGrid.Rows)
                {
                    statusChecked = GetStatusForRow(CVaultDataSource.Band, CVaultGrid.ActiveRow);
                }
                
                foreach (KeyValuePair<string, bool> kvp in statusChecked)
                    Console.WriteLine("Status site:" + kvp.Key + " is " + kvp.Value.ToString());
                Console.WriteLine("\r\n");
            }
