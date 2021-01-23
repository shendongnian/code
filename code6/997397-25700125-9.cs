    using System;
    using System.Collections;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;
    using WpfApplication1.Helpers;
    namespace WpfApplication1.CustomControls
    {
        public class TextBlockComplex : TextBlock
        {
            // Content
            public StringFormatContainer Content { get { return (StringFormatContainer)GetValue(ContentProperty); } set { SetValue(ContentProperty, value); } }
            public static readonly DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(StringFormatContainer), typeof(TextBlockComplex), new PropertyMetadata(null));
            private static readonly DependencyPropertyDescriptor _dpdValue = DependencyPropertyDescriptor.FromProperty(StringFormatContainer.ValueProperty, typeof(StringFormatContainer));
            private static readonly DependencyPropertyDescriptor _dpdValues = DependencyPropertyDescriptor.FromProperty(StringFormatContainer.ValuesProperty, typeof(StringFormatContainer));
            private static readonly DependencyPropertyDescriptor _dpdStringFormat = DependencyPropertyDescriptor.FromProperty(StringFormatContainer.StringFormatProperty, typeof(StringFormatContainer));
            private static readonly DependencyPropertyDescriptor _dpdContent = DependencyPropertyDescriptor.FromProperty(TextBlockComplex.ContentProperty, typeof(StringFormatContainer));
            private EventHandler _valueChangedHandler;
            private NotifyCollectionChangedEventHandler _valuesChangedHandler;
            protected override IEnumerator LogicalChildren { get { yield return Content; } }
            static TextBlockComplex()
            {
                // take default style from TextBlock
                DefaultStyleKeyProperty.OverrideMetadata(typeof(TextBlockComplex), new FrameworkPropertyMetadata(typeof(TextBlock)));
            }
            public TextBlockComplex()
            {
                _valueChangedHandler = delegate { AddListeners(this.Content); UpdateText(); };
                _valuesChangedHandler = delegate { AddListeners(this.Content); UpdateText(); };
                this.Loaded += TextBlockComplex_Loaded;
            }
            void TextBlockComplex_Loaded(object sender, RoutedEventArgs e)
            {
                OnContentChanged(this, EventArgs.Empty); // initial call
                _dpdContent.AddValueChanged(this, _valueChangedHandler);
                this.Unloaded += delegate { _dpdContent.RemoveValueChanged(this, _valueChangedHandler); };
            }
            /// <summary>
            /// Reacts to a new topmost StringFormatContainer
            /// </summary>
            private void OnContentChanged(object sender, EventArgs e)
            {
                this.AddLogicalChild(this.Content); // inherits DataContext
                _valueChangedHandler(this, EventArgs.Empty);
            }
            /// <summary>
            /// Updates Text to the Content values
            /// </summary>
            private void UpdateText()
            {
                this.Text = Content.GetValue() as string;
            }
            /// <summary>
            /// Attaches listeners for changes in the Content tree
            /// </summary>
            private void AddListeners(StringFormatContainer cont)
            {
                // in case they have been added before
                RemoveListeners(cont);
                // listen for changes to values collection
                cont.CollectionChanged += _valuesChangedHandler;
                // listen for changes in the bindings of the StringFormatContainer
                _dpdValue.AddValueChanged(cont, _valueChangedHandler);
                _dpdValues.AddValueChanged(cont, _valueChangedHandler);
                _dpdStringFormat.AddValueChanged(cont, _valueChangedHandler);
                // prevent memory leaks
                cont.Unloaded += delegate { RemoveListeners(cont); };
                foreach (var c in cont.Values) AddListeners(c); // recursive
            }
            /// <summary>
            /// Detaches listeners
            /// </summary>
            private void RemoveListeners(StringFormatContainer cont)
            {
                cont.CollectionChanged -= _valuesChangedHandler;
                _dpdValue.RemoveValueChanged(cont, _valueChangedHandler);
                _dpdValues.RemoveValueChanged(cont, _valueChangedHandler);
                _dpdStringFormat.RemoveValueChanged(cont, _valueChangedHandler);
            }
        }
    }
