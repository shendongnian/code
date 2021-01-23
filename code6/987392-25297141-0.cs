    using System;
    using System.Linq;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using System.Reflection;
    namespace WpfApplication1.Behaviors
    {
        public class NullableComboBoxBehavior : Behavior<ComboBox>
        {
            // IsNullValueSelected 
            public static readonly DependencyProperty IsNullValueSelectedProperty = DependencyProperty.Register("IsNullValueSelected", typeof(bool), typeof(NullableComboBoxBehavior), new PropertyMetadata(false));
            public bool IsNullValueSelected { get { return (bool)GetValue(IsNullValueSelectedProperty); } set { SetValue(IsNullValueSelectedProperty, value); } }
            private const string AllCaption = "- All -";
            protected override void OnAttached()
            {
                DependencyPropertyDescriptor.FromProperty(ComboBox.ItemsSourceProperty, typeof(ComboBox))
                        .AddValueChanged(this.AssociatedObject, OnItemsSourceChanged);
                DependencyPropertyDescriptor.FromProperty(ComboBox.SelectedItemProperty, typeof(ComboBox))
                        .AddValueChanged(this.AssociatedObject, OnSelectedItemChanged);
                // initial call
                OnItemsSourceChanged(this, EventArgs.Empty);
                OnSelectedItemChanged(this, EventArgs.Empty);
            }
            private void OnSelectedItemChanged(object sender, EventArgs e)
            {
                var cbx = this.AssociatedObject;
                // If the caption of the selected item is either "- All -" or no item is selected, 
                // set IsNullValueSelected to true
                if (cbx.SelectedItem != null)
                {
                    // get caption directly or by way of DisplayMemberPath
                    string caption = cbx.SelectedItem.GetType() == typeof(string) ?
                                        (string)cbx.SelectedItem :
                                        GetDisplayMemberProperty(cbx.SelectedItem).GetValue(cbx.SelectedItem).ToString();
                    if (caption == AllCaption || caption == null)
                        this.IsNullValueSelected = true;
                    else
                        this.IsNullValueSelected = false;
                }
                else
                    this.IsNullValueSelected = true;
            }
            private void OnItemsSourceChanged(object sender, EventArgs e)
            {
                var cbx = this.AssociatedObject;
                // assuming an ItemsSource that implements IList
                if (cbx.ItemsSource != null && (IList)cbx.ItemsSource != null)
                {
                    Type T = cbx.ItemsSource.AsQueryable().ElementType;
                    object obj;
                    if (T == typeof(string))
                        obj = AllCaption; // set AllCaption directly
                    else if (T.GetConstructor(Type.EmptyTypes) != null)
                    {
                        // set AllCaption by way of DisplayMemberPath
                        obj = Activator.CreateInstance(T);
                        GetDisplayMemberProperty(obj).SetValue(obj, AllCaption);
                    }
                    else
                        throw new Exception("Only types with parameterless ctors or string are supported.");
                    // insert the null item
                    ((IList)cbx.ItemsSource).Insert(0, obj);
                    // select first item (optional). 
                    // If you uncomment this, remove the OnSelectedItemChanged call in OnAttached 
                    //cbx.SelectedIndex = 0;
                }
            }
            private PropertyInfo GetDisplayMemberProperty(object obj)
            {
                if (string.IsNullOrEmpty(this.AssociatedObject.DisplayMemberPath))
                    throw new Exception("This will only work if DisplayMemberPath is set.");
                // get the property info of the DisplayMemberPath
                return obj.GetType().GetProperty(this.AssociatedObject.DisplayMemberPath);
            }
        }
    }
