    public static class Utilities
    {
        public static void loadDGVSettings(DataGridView DGV)
        {
            if (DGV != null)
            {
                //pull the custom user settings for the datagridview
                DGV.AlternatingRowsDefaultCellStyle.BackColor = 
                    Properties.Settings.Default.AltRowColor;
                DGV.DefaultCellStyle.BackColor = Properties.Settings.Default.RowColor;
                DGV.Font = Properties.Settings.Default.RowFont;
                // ...
            }
        }
    }
