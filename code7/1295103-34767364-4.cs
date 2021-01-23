    public interface IStatusContainer
    {
        bool IsReady { get; set; }
    }
    public class DataGridVirtualizationBindingTestVm : IStatusContainer
    {
        public DataGridVirtualizationBindingTestVm()
        {
            Records = new ObservableCollection<Record>(Enumerable.Range(1, 4000).Select(i => new Record { Field1 = i.ToString(), Container = this }));
         // ...
    }
    public class Record
    {
        public IStatusContainer Container { get; set; }
        public string Field1 { get; set; }
    }
    <DataTemplate x:Key="IsReadyTemplate">
        <TextBox Text="{Binding Path=Container.IsReady}"/>
    </DataTemplate>
