    public class MyComboVM
    {
        public ObservableCollection<Texts> MyCombo { get; set; }        
        public MyComboVM()
        {
            MyCombo = new ObservableCollection<Texts>();
            MyCombo.Add(new Texts() { Text = "This is one" });
            MyCombo.Add(new Texts() { Text = "This is Two" });
        }        
    }
    public class Texts
    {
        public string Text { get; set; }
    }
