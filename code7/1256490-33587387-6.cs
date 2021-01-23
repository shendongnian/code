    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Q1
    {
        public class MyDataTemplateSelector : System.Windows.Controls.DataTemplateSelector
        {
            public System.Windows.DataTemplate IntDataTemplate { get; set; }
            public System.Windows.DataTemplate StringDataTemplate { get; set; }
            public MyDataTemplateSelector()
            {
                IntDataTemplate = new System.Windows.DataTemplate();
                StringDataTemplate = new System.Windows.DataTemplate();
            }
            public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
            {
                if (item is Int32)
                {
                    return IntDataTemplate;
                }
                else
                {
                    return StringDataTemplate;
                }
            }
        }
    }
