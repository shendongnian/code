        public partial class UserControl1 : UserControl
        {
            public List<CustomField> Fields = new List<CustomField>();
            public UserControl1()
            {
                InitializeComponent();
            }
    
            public UserControl1(string mask)
            {
                InitializeComponent();
                BuildControls(mask);
            }
    
            public void BuildControls(string mask)
            {
                //Parsing Input
                var fields = Regex.Split(mask, @"(.*?\}\s)");
                foreach (var item in fields)
                {
                    if (item != "")
                    {
                        int index = item.IndexOf('{');
                        string namestring = item.Substring(0, index).Trim();
                        var field = new CustomField() { Name = namestring };
    
                        string valuesstring = item.Substring(index, item.Length - index).Trim();
                        var values = valuesstring.Split(new char[] { '{', '}' }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var val in values)
                        {
                            var valuewrapper = new FieldValue() { Value = val };
                            field.Values.Add(valuewrapper);
                        }
                        Fields.Add(field);
                    }
                }
    
                foreach (var field in Fields)
                {
                    var stackPanel = new StackPanel() { Orientation = Orientation.Horizontal };
                    var label = new Label() { Content = field.Name, Margin = new Thickness(4) };
                    stackPanel.Children.Add(label);
                    foreach (var item in field.Values)
                    {
                        var tb = new TextBox() { Margin = new Thickness(4), Width = 200 };
                        tb.SetBinding(TextBox.TextProperty, new Binding() { Path = new PropertyPath("Value"), Source = item, Mode = BindingMode.TwoWay });
                        stackPanel.Children.Add(tb);
                    }
                    root.Children.Add(stackPanel);
                }
            }
    
    
        }
    
        public class CustomField
        {
            public string Name { get; set; }
            public List<FieldValue> Values = new List<FieldValue>();
        }
        public class FieldValue
        {
            public string Value { get; set; }
        }
