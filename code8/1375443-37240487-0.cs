    using System;
    using System.Collections;
    
    using Xamarin.Forms;
    
    namespace HLI.Forms.Controls
    {
        public class HliItemsView : ScrollView
        {
            public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(
                "ItemTemplate",
                typeof(DataTemplate),
                typeof(HliItemsView),
                null,
                propertyChanged: (bindable, value, newValue) => Populate(bindable));
    
            public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
                "ItemsSource",
                typeof(IEnumerable),
                typeof(HliItemsView),
                null,
                BindingMode.OneWay,
                propertyChanged: (bindable, value, newValue) => Populate(bindable));
    
            public IEnumerable ItemsSource
            {
                get
                {
                    return (IEnumerable)this.GetValue(ItemsSourceProperty);
                }
    
                set
                {
                    this.SetValue(ItemsSourceProperty, value);
                }
            }
    
            public DataTemplate ItemTemplate
            {
                get
                {
                    return (DataTemplate)this.GetValue(ItemTemplateProperty);
                }
    
                set
                {
                    this.SetValue(ItemTemplateProperty, value);
                }
            }
    
            private static void Populate(BindableObject bindable)
            {
                var repeater = (HliItemsView)bindable;
    
                // Clean
                repeater.Content = null;
    
                // Only populate once both properties are recieved
                if (repeater.ItemsSource == null || repeater.ItemTemplate == null)
                {
                    return;
                }
    
                // Create a stack to populate with items
                var list = new StackLayout();
    
                foreach (var viewModel in repeater.ItemsSource)
                {
                    var content = repeater.ItemTemplate.CreateContent();
                    if (!(content is View) && !(content is ViewCell))
                    {
                        throw new Exception($"Invalid visual object {nameof(content)}");
                    }
    
                    var view = content is View ? content as View : ((ViewCell)content).View;
                    view.BindingContext = viewModel;
    
                    list.Children.Add(view);
                }
    
                // Set stack as conent to this ScrollView
                repeater.Content = list;
            }
        }
    }
