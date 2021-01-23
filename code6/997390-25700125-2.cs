    using System.Linq;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Windows;
    namespace WpfApplication1.Helpers
    {
        public class StringFormatContainer : FrameworkElement
        {
            // Values
            private static readonly DependencyPropertyKey ValuesPropertyKey = DependencyProperty.RegisterReadOnly("Values", typeof(ObservableCollection<StringFormatContainer>), typeof(StringFormatContainer), new FrameworkPropertyMetadata(new ObservableCollection<StringFormatContainer>()));
            public static readonly DependencyProperty ValuesProperty = ValuesPropertyKey.DependencyProperty;
            public ObservableCollection<StringFormatContainer> Values { get { return (ObservableCollection<StringFormatContainer>)GetValue(ValuesProperty); } }
            // StringFormat
            public static readonly DependencyProperty StringFormatProperty = DependencyProperty.Register("StringFormat", typeof(string), typeof(StringFormatContainer), new PropertyMetadata(default(string)));
            public string StringFormat { get { return (string)GetValue(StringFormatProperty); } set { SetValue(StringFormatProperty, value); } }
            // Value
            public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(StringFormatContainer), new PropertyMetadata(default(object)));
            public object Value { get { return (object)GetValue(ValueProperty); } set { SetValue(ValueProperty, value); } }
            public StringFormatContainer()
                : base()
            {
                SetValue(ValuesPropertyKey, new ObservableCollection<StringFormatContainer>());
                this.Values.CollectionChanged += OnValuesChanged;
            }
            /// <summary>
            /// The implementation of LogicalChildren allows for DataContext propagation.
            /// This way, the DataContext needs only be set on the outermost instance of StringFormatContainer.
            /// </summary>
            void OnValuesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                if (e.NewItems != null)
                {
                    foreach (var value in e.NewItems)
                        AddLogicalChild(value);
                }
                if (e.OldItems != null)
                {
                    foreach (var value in e.OldItems)
                        RemoveLogicalChild(value);
                }
            }
            /// <summary>
            /// Recursive function to piece together the value from the StringFormatContainer hierarchy
            /// </summary>
            public object GetValue()
            {
                object value = null;
                if (this.StringFormat != null)
                {
                    // convention: if StringFormat is set, Values take precedence over Value
                    if (this.Values.Any())
                        value = string.Format(this.StringFormat, this.Values.Select(v => (object)v.GetValue()).ToArray());
                    else if (Value != null)
                        value = string.Format(this.StringFormat, Value);
                }
                else
                {
                    // convention: if StringFormat is not set, Value takes precedence over Values
                    if (Value != null)
                        value = Value;
                    else if (this.Values.Any())
                        value = string.Join(string.Empty, this.Values);
                }
                return value;
            }
            protected override IEnumerator LogicalChildren
            {
                get
                {
                    if (Values == null) yield break;
                    foreach (var v in Values) yield return v;
                }
            }
        }
    }
