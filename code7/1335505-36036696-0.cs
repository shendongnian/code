            private void add_new_row(string val1, string val2, string val3, string val4, string val5)
            {
              //gcProcess
              if (gcProcess.DataSource != null)
              {
                gcProcess.BeginUpdate();
                DataTable dtMain = ((DataTable)gcProcess.DataSource);
                DataRow newRow = dtMain.NewRow();
                newRow[0] = val1;
                newRow[1] = val2;
                newRow[2] = val3;
                newRow[3] = val4;
                newRow[4] = val5;
                dtMain.Rows.Add(newRow);
                gcProcess.EndUpdate();
              }
            }
