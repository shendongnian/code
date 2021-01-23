    // Make sure to make a reference to UltraWinGrid.
    using Infragistics.Win.UltraWinGrid;
    public class ClassName
    {
        // Do it in the construct of your class
        public ClassName()
        {
            // Use the UltraGrid name you assigned to
            // your UltraGrid.
            ugMyUltraGrid.DataSource = loadData();
        }
    }
