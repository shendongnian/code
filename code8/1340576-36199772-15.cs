    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Media;
    namespace WpfApplication1
    {
        [ValueConversion(typeof(bool), typeof(Brush))]
        public sealed class BooleanToBrushConverter : IValueConverter
        {
            public Brush TrueBrush { get; set; }
            public Brush FalseBrush { get; set; }
            public object Convert(object value, Type _, object __, CultureInfo ___) =>
                (bool)value ? this.TrueBrush : this.FalseBrush;
            public object ConvertBack(object _, Type __, object ___, CultureInfo ____) =>
                DependencyProperty.UnsetValue; // unused
        }
    }
