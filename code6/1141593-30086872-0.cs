        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            bool valid;
            DataGridView dgv = (DataGridView)sender;
            DataGridViewCell cell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
            // Regex pattern acceptable for a time format
            Regex timeRegex = new Regex("^([0-1]?[0-9]|[2][0-3]):([0-5][0-9])$");
            if (cell.Value == null || cell.Value.ToString() == string.Empty)
            {
                cell.Style.BackColor = Color.White;
                cell.ToolTipText = string.Empty;
                cell.Tag = "empty";
                valid = false;
            }
            // If the regex does not match then the format is invalid
            else if (!timeRegex.IsMatch(cell.Value.ToString()))
            {
                cell.Style.BackColor = Color.Beige;
                cell.ToolTipText = "Invalid format.";
                cell.Tag = "invalid";
                valid = false;
            }
            else
            {
                cell.Style.BackColor = Color.White;
                cell.ToolTipText = string.Empty;
                cell.Tag = "valid";
                valid = true;
            }
            if(valid)
            {
                string timeToConvert = cell.Value.ToString();
                string timeConvertReady = timeToConvert.Replace(":", "");
                int timeAsInt = Convert.ToInt32(timeConvertReady);
                updateTimeInDatabase(timeAsInt);
            }
        }
