    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Shapes;
    namespace _34639801
    {
        [ContentProperty("Children")]
        public class Composite : FrameworkElement
        {
            public static readonly DependencyProperty ChildrenProperty = DependencyProperty.Register("Children",
                typeof(IList),
                typeof(Composite),
                new PropertyMetadata(default(IList)));
            [Category("Common")]
            public IList Children
            {
                get { return (IList)GetValue(ChildrenProperty); }
                set { SetValue(ChildrenProperty, value); }
            }
        
            //Get children by name.
            public Shape this[string name]
            {
                get
                {
                    foreach (Shape s in Children)
                    {
                        if (s.Name.Equals(name))
                        {
                            return s;
                        }
                    }
                    return null;
                }
            }
            public Composite()
            {
                SetCurrentValue(ChildrenProperty, new ObservableCollection<Shape>());
            }
        }
    }
