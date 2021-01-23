    public class VeryUnrefinedViewmodel
    {
        public string SelectedName { get; set; }
    }
    // ...
    VeryUnrefinedViewmodel _DataContextInstance = new VeryUnrefinedViewmodel();
    // your initialization code
    comboBox_warnColor.ItemsSource = typeof(Colors).GetProperties();
    comboBox_warnColor.DataContext = _DataContextInstance;
    // _DataContextInstance.SelectedName will contain the name of the selected color
