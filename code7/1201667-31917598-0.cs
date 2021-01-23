    public interface MyMultiSelector
    {
        IList SelectedItems { get; }
    }
    public class MyListBox : ListBox, MyMultiSelector
    {
    }
    public class MyDataGrid : DataGrid, MyMultiSelector
    {
    }
