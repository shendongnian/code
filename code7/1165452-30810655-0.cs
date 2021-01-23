    public class Form1
    {
        private DataGridView[] subFrames = new DataGridView[16];
        // other code
        private void BuildGrids()
        {
            this.DataGridView1 = BuildFirstGrid();
            subFrames[0] = this.DataGridView1;
            // continue for the rest of the grids
        }
        private void StyleGrids()
        {
            foreach (var grid in subFrames)
                ApplyStyling(grid);
        }
    }
