        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public ComboboxItem(string text, string value)
            {
                Text = text;
                Value = value;
            }
            public override string ToString()
            {
                return Text;
            }
        }
        private  void SelectCmbItemByValue( ComboBox cbo, string value)
        {
            for (int i = 0; i < cbo.Items.Count; i++)
            {
                ComboboxItem ci = (ComboboxItem)cbo.Items[i];
                string _value = ci.Value.ToString();
                if (ci != null && _value == value)
                {
                    cbo.SelectedIndex = i;
                    break;
                }
            }
        }
