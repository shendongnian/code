    public interface IMultiSelector
    {
        IList SelectedItems { get; }
    }
    public class MyListBox : ListBox, IMultiSelector
    {
    }
    public class MyDataGrid : DataGrid, IMultiSelector
    {
    }
