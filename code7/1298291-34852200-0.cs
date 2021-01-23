            string rows = "FacilityID:12787 FacilityName:ACME Medical Center FacilityLocation:XYZ";
            DataTable tbl = new DataTable("test");
            if (rows.Length != 0)
            {
                tbl.Columns.Add("FacilityID");
                tbl.Columns.Add("FacilityName");
                tbl.Columns.Add("FacilityLocation");
                var newRow = tbl.NewRow();
                newRow[0] = GetID(rows);
                newRow[1] = GetName(rows);
                newRow[2] = GetLocation(rows);
                tbl.Rows.Add(newRow);
                dataGridView1.DataSource = tbl.DefaultView;
            }
        }
        private string GetID(string str)
        {
            if (!string.IsNullOrEmpty(str.Split(':')[1]))
            {
                return str.Split(':')[1].Replace("FacilityName", string.Empty);
            }
            return string.Empty;
        }
        private string GetName(string str)
        {
            if (!string.IsNullOrEmpty(str.Split(':')[2]))
            {
                return str.Split(':')[2].Replace("FacilityLocation", string.Empty);
            }
            return string.Empty;
        }
        private string GetLocation(string str)
        {
            if (!string.IsNullOrEmpty(str.Split(':')[3]))
            {
                return str.Split(':')[3];
            }
            return string.Empty;
        }
