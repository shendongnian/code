        public string TotalHoliday()
        {
            int RegHD = 0;
            int SpclHD = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) break;
                object HD = row.Cells["Holidays"].Value;
                if (!Convert.IsDBNull(HD) && HD != null && HD.ToString() == "Regular")
                {
                    RegHD++;
                }
                else if (!Convert.IsDBNull(HD) && HD != null && HD.ToString() == "Special Non-working")
                {
                    SpclHD++;
                }
            }
            int totHD = RegHD + SpclHD;
            string totalHD = totHD.ToString();
            return totalHD;
        }
