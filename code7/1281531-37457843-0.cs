    public class Grid
        : DataGridView
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            // Touching the TopLeftHeaderCell here prevents
            // System.InvalidOperationException:
            // This operation cannot be performed while
            // an auto-filled column is being resized.
    
            var topLeftHeaderCell = TopLeftHeaderCell;
    
            base.OnHandleCreated(e);
        }
    }
