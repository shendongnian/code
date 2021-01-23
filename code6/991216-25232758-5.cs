        public class RadioButtonBinding : MultiBinding
    {
        public RadioButtonBinding(string propName)
        { 
            Bindings.Add(new Binding(propName));
            Bindings.Add(new Binding("Content") { RelativeSource = new RelativeSource(RelativeSourceMode.Self) });
            Converter = new SettingsConverter();
        }
    }
