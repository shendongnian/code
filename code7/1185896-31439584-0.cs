    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace XyWpf.Library.Controls
    {
        public class LabelGrid : Grid
        {
            public GridLength LabelColumnWidth { get; set; }
            public GridLength ContentColumnWidth { get; set; }
    
            public LabelGrid()
            {
                LabelColumnWidth = GridLength.Auto;
                ContentColumnWidth = new GridLength(1, GridUnitType.Star);
            }
    
            public override void EndInit()
            {
                base.EndInit();
    
                var children = this.Children.Cast<UIElement>().ToList();
                this.Children.Clear();
    
                this.ColumnDefinitions.Add(new ColumnDefinition() { Width = LabelColumnWidth });
                this.ColumnDefinitions.Add(new ColumnDefinition() { Width = ContentColumnWidth });
    
                for (int i = 0; i < children.Count; i++)
                {
                    this.RowDefinitions.Add(new RowDefinition() { Height = GridLength.Auto });
    
                    var child = children[i];
                    Grid.SetColumn(child, 1);
                    Grid.SetRow(child, i);
                    this.Children.Add(child);
    
                    var label = new Label() { Content = Element.GetLabel(child) };
                    Grid.SetColumn(label, 0);
                    Grid.SetRow(label, i);
                    this.Children.Add(label);
    
                    label.SetBinding(Label.VisibilityProperty, new Binding("Visibility")
                    {
                        Mode = BindingMode.OneWay,
                        Source = child
                    });
                }
            }
        }
    
        public partial class Element
        {
            public static readonly DependencyProperty LabelProperty =
                DependencyProperty.RegisterAttached("Label",
                    typeof(string), typeof(Element), new PropertyMetadata(string.Empty));
    
            public static object GetLabel(UIElement element)
            {
                return element.GetValue(LabelProperty);
            }
    
            // required
            public static void SetLabel(UIElement element, string value)
            {
                element.SetValue(LabelProperty, value);
            }
        }
    }
