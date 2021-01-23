    namespace IronPythonControlsExample {
        public class IronPythonControl : MarkupExtension
        {
            public string Name;
            public IronPythonControl(string name)
            {
                Name = name;   
            }
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                if (!string.IsNullOrEmpty(Name))
                {
                  return LoadControl(Name);
                }
            }
            
            public FrameworkElement LoadControl(string name){/*Load XAML Control from database here*/}
        }
    }
