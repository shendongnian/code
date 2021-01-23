    public class CustomDataGridView : DataGridView
    {
        protected override bool ProcessDataGridViewKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                // custom logic here
            }
            return base.ProcessDataGridViewKey(e);
        }
    }
