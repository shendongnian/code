    public class DataGridCellsPresenter : System.Windows.Controls.Primitives.DataGridCellsPresenter
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new DataGridCell(); /* the one in our namespace */
        }
    }
