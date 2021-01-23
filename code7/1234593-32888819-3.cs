    private void SaveCvaultData()
            {
                GetStatusForRow(CVaultDataSource.Band, CVaultGrid.ActiveRow);
                Dictionary<string, bool> statusChecked = GetStatusForRow(CVaultDataSource.Band, CVaultGrid.ActiveRow);
                foreach (KeyValuePair<string, bool> kvp in statusChecked)
                    MessageBox.Show("Status site:" + kvp.Key + " is " + kvp.Value.ToString());
            }
