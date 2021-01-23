     DataTable dataTable = (DataTable)scnDataGrd.DataSource;
            int index1 = -1;
            bool found = false;
            DataGridTableStyle ts = new DataGridTableStyle();
            foreach (DataRow dr in dataTable.Rows)
            {
                index1++;
                if (dr[tableColIndex].ToString() == textValue)
                {
                    scnDataGrd.Select(index1);
                    scnDataGrd.SelectionForeColor = Color.Red;
                    dr["Current"] = true;
                    break;
                }
                else
                {
                    dr[0] = "Not Found";
                }
            }
