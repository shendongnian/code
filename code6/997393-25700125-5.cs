    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Interactivity;
    using WpfApplication1.Helpers;
    namespace WpfApplication1.Behaviors
    {
        /// <summary>
        /// Behavior to allow for a complex MultiBinding of TextBlock.TextProperty
        /// </summary>
        public class TextBindingBehavior : Behavior<TextBlock>
        {
            private static readonly DependencyPropertyDescriptor _dpdValue = DependencyPropertyDescriptor.FromProperty(StringFormatContainer.ValueProperty, typeof(StringFormatContainer));
            private static readonly DependencyPropertyDescriptor _dpdValues = DependencyPropertyDescriptor.FromProperty(StringFormatContainer.ValuesProperty, typeof(StringFormatContainer));
            private static readonly DependencyPropertyDescriptor _dpdStringFormat = DependencyPropertyDescriptor.FromProperty(StringFormatContainer.StringFormatProperty, typeof(StringFormatContainer));
            private static readonly DependencyPropertyDescriptor _dpdDataContext = DependencyPropertyDescriptor.FromProperty(FrameworkElement.DataContextProperty, typeof(TextBlock));
            private EventHandler _dataContextChangedHandler;
            private EventHandler _valueChangedHandler;
            // Content
            public StringFormatContainer Content { get { return (StringFormatContainer)GetValue(ContentProperty); } set { SetValue(ContentProperty, value); } }
            public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(StringFormatContainer), typeof(TextBindingBehavior), new PropertyMetadata(null));
            protected override void OnAttached()
            {
                // define handlers once
                _dataContextChangedHandler = delegate { SetDataContext(); };
                _valueChangedHandler = delegate { UpdateText(); };
                // listen for datacontext change, prevent memory leak
                _dpdDataContext.AddValueChanged(this.AssociatedObject, _dataContextChangedHandler);
                this.AssociatedObject.Unloaded += delegate { _dpdDataContext.RemoveValueChanged(this.AssociatedObject, _dataContextChangedHandler); };
                // add to logical tree for resources propagation
                var mi = this.AssociatedObject.GetType().GetMethod("AddLogicalChild", BindingFlags.NonPublic | BindingFlags.Instance);
                if (mi != null) mi.Invoke(this.AssociatedObject, new object[] { this.Content });
                // initial DataContext set
                SetDataContext();
                base.OnAttached();
            }
            /// <summary>
            /// Updates the Text of the associated TextBlock
            /// </summary>
            private void UpdateText()
            {
                this.AssociatedObject.Text = Content.GetValue() as string;
            }
            /// <summary>
            /// Sets the DataContext of the Content to the DataContext of the TextBlock
            /// </summary>
            private void SetDataContext()
            {
                if (Content != null && this.AssociatedObject != null)
                {
                    Content.DataContext = this.AssociatedObject.DataContext;
                    AttachBindings(Content);
                    UpdateText();
                }
            }
            /// <summary>
            /// Activates bindings and adds change listeners
            /// </summary>
            private void AttachBindings(StringFormatContainer cont)
            {
                // recreate all bindings
                ActivateBinding(cont, StringFormatContainer.ValueProperty);
                ActivateBinding(cont, StringFormatContainer.ValuesProperty);
                ActivateBinding(cont, StringFormatContainer.StringFormatProperty);
                // recursive call
                foreach (var v in cont.Values) AttachBindings(v);
                AddListeners(cont);
            }
            /// <summary>
            /// Adds listeners for changes in the Content
            /// </summary>
            private void AddListeners(StringFormatContainer cont)
            {
                // listen for changes in the bindings of the StringFormatContainer
                _dpdValue.AddValueChanged(cont, _valueChangedHandler);
                _dpdValues.AddValueChanged(cont, _valueChangedHandler);
                _dpdStringFormat.AddValueChanged(cont, _valueChangedHandler);
                // prevent memory leaks
                cont.Unloaded += (s, e) =>
                {
                    _dpdValue.RemoveValueChanged(cont, _valueChangedHandler);
                    _dpdValues.RemoveValueChanged(cont, _valueChangedHandler);
                    _dpdStringFormat.RemoveValueChanged(cont, _valueChangedHandler);
                };
            }
            /// <summary>
            /// Recreates an existing binding, workaround for activating the binding
            /// For some reason, bindings are not set to active when the datacontext is set.
            /// http://stackoverflow.com/questions/12821107/how-to-set-bindingexpression-status-to-active-programmatically
            /// </summary>
            private void ActivateBinding(FrameworkElement fe, DependencyProperty propdp)
            {
                // DynamicResources: add relevant resources to StringFormatContainer.Resources
                var re = fe.ReadLocalValue(propdp);
                if (re != null && re.GetType().ToString() == "System.Windows.ResourceReferenceExpression")
                {
                    var cachedValue = re.GetType().GetField("_cachedResourceValue", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(re);
                    if (cachedValue != null)
                    {
                        var dict = cachedValue.GetType().GetProperty("Dictionary", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(cachedValue) as ResourceDictionary;
                        if (dict != null && !fe.Resources.MergedDictionaries.Contains(dict))
                            fe.Resources.MergedDictionaries.Add(dict);
                    }
                }
                // Bindings: activate
                var be = fe.GetBindingExpression(propdp);
                if (be != null)
                {
                    Binding newBinding = new Binding(be.ParentBinding.Path.Path);
                    newBinding.Source = fe.DataContext;
                    fe.SetBinding(propdp, newBinding);
                    be = fe.GetBindingExpression(propdp);
                    be.UpdateTarget();
                }
            }
        }
    }
