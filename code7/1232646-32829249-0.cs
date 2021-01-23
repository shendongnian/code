    public static class myExtensionsMethods
    {
        public static void validateRow(this object sender)
        {
            int columnIndex = 10;
            GridViewRow myRow = ((Control)sender).Parent as GridViewRow;
            myRow.Cells[columnIndex].Text = "Validated";
        }
    }
