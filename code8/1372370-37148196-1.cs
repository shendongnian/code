    public class ComboViewModel : BaseViewModel
    {
      public ComboViewModel()
      {
         Index = -1;
         Value = string.Empty;
         Items = null;
      }
      public int Index
      {
         get { return (int)GetValue("Index"); }
         set { SetValue("Index", value); }
      }
      public string Value
      {
         get { return (string)GetValue("Value"); }
         set { SetValue("Value", value); }
      }
      public List<string> Items
      {
         get { return (List<string>)GetValue("Items"); }
         set { SetValue("Items",value); }
      }
    }
