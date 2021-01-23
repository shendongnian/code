    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Primitive primitive;
    
                primitive = new Sphere();
                //  primitive = new Cube();
                DataContext = primitive;
            }
        }
    
        internal abstract class Primitive
        {
            public abstract string Description { get; }
        }
    
        internal class Cube : Primitive
        {
            public override string Description
            {
                get { return "Cube"; }
            }
        }
    
        internal class Sphere : Primitive
        {
            public override string Description
            {
                get { return "Sphere"; }
            }
        }
    
        public class MyTemplateSelector : DataTemplateSelector
        {
            public override DataTemplate SelectTemplate(object item, DependencyObject container)
            {
                var frameworkElement = container as FrameworkElement;
                if (frameworkElement != null && item != null)
                {
                    if (item is Cube)
                    {
                        return frameworkElement.FindResource("CubeTemplate") as DataTemplate;
                    }
                    if (item is Sphere)
                    {
                        return frameworkElement.FindResource("SphereTemplate") as DataTemplate;
                    }
                }
    
                return base.SelectTemplate(item, container);
            }
        }
    }
