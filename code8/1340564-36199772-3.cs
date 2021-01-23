    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    namespace WpfApplication1
    {
        [ValueConversion(typeof(bool), typeof(SolidColorBrush))]
        public sealed class BooleanToSolidColorBrushConverter : IValueConverter
        {
            private SolidColorBrush trueBrush;
            public Color TrueColor
            {
                get
                {
                    return this.trueBrush.Color;
                }
                set
                {
                    if (this.trueBrush?.Color == value)
                    {
                        return;
                    }
                    this.trueBrush = new SolidColorBrush(value);
                    this.trueBrush.Freeze();
                }
            }
            private SolidColorBrush falseBrush;
            public Color FalseColor
            {
                get
                {
                    return this.falseBrush.Color;
                }
                set
                {
                    if (this.falseBrush?.Color == value)
                    {
                        return;
                    }
                    this.falseBrush = new SolidColorBrush(value);
                    this.falseBrush.Freeze();
                }
            }
            public object Convert(object value, Type _, object __, CultureInfo ___) =>
                (bool)value ? this.trueBrush : this.falseBrush;
            public object ConvertBack(object _, Type __, object ___, CultureInfo ____) =>
                DependencyProperty.UnsetValue; // unused
        }
    }
