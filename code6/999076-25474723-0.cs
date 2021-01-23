        public static void Categorize(DataGridView dgv)
        {
            // Set colors for each category
            Color apples = Color.Red,
                  bananas = Color.Yellow,
                  oranges = Color.Orange;
            // Loop the rows
            foreach (DataGridViewRow row in dgv.Rows)
            {
                // Read category
                string category = row.Cells["GroupColumn"].Value.ToString();
                // Set color according to category
                switch (category)
                {
                    case "Apple": row.DefaultCellStyle.BackColor = apples; return;
                    case "Banana": row.DefaultCellStyle.BackColor = bananas; return;
                    // If the group wasn't listed, skip
                    default: return;
                }
            }
        }
