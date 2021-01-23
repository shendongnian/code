    public class ControlClearer
    {
        private static Dictionary<Type, Action<Control>> lookup = new Dictionary<Type, Action<Control>>();
        static ControlClearer()
        {
            AddMapping((TextBox control) => control.Text = "");
            AddMapping((ComboBox control) => control.SelectedIndex = -1);
            AddMapping((CheckBox control) => control.Checked = false);
        }
        private static void AddMapping<T>(Action<T> clearAction)
            where T : Control
        {
            lookup[typeof(T)] = control => clearAction((T)(object)control);
        }
        public static void Clear<T>(T control)
            where T : Control
        {
            //todo support case where T isn't in the dictionary
            lookup[typeof(T)](control);
        }
    }
