    using System;
    using System.ComponentModel;
    using System.Windows.Media;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Markup;
    namespace HollowEarth
    {
        public class SignalBars : ContentControl
        {
            static SignalBars()
            {
                DefaultStyleKeyProperty.OverrideMetadata(typeof(SignalBars), new FrameworkPropertyMetadata(typeof(SignalBars)));
            }
            #region Value Property
            public double Value
            {
                get { return (double)GetValue(ValueProperty); }
                set { SetValue(ValueProperty, value); }
            }
            public static readonly DependencyProperty ValueProperty =
                DependencyProperty.Register("Value", typeof(double), typeof(SignalBars),
                    new PropertyMetadata(0d));
            #endregion Value Property
            #region InactiveBarFillBrush Property
            [Bindable(true)]
            [Category("Appearance")]
            [DefaultValue("White")]
            public Brush InactiveBarFillBrush
            {
                get { return (Brush)GetValue(InactiveBarFillBrushProperty); }
                set { SetValue(InactiveBarFillBrushProperty, value); }
            }
            public static readonly DependencyProperty InactiveBarFillBrushProperty =
                DependencyProperty.Register("InactiveBarFillBrush", typeof(Brush), typeof(SignalBars),
                    new FrameworkPropertyMetadata(Brushes.White));
            #endregion InactiveBarFillBrush Property
        }
        public class ComparisonConverter : MarkupExtension, IMultiValueConverter
        {
            public virtual object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                if (values.Length != 2)
                {
                    throw new ArgumentException("Exactly two values are expected");
                }
                var d1 = GetDoubleValue(values[0]);
                var d2 = GetDoubleValue(values[1]);
                return Compare(d1, d2);
            }
            /// <summary>
            /// Overload in subclasses to create LesserThan, EqualTo, whatever.
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            /// <returns></returns>
            protected virtual bool Compare(double a, double b)
            {
                throw new NotImplementedException();
            }
            protected static double GetDoubleValue(Object o)
            {
                if (o == null || o == DependencyProperty.UnsetValue)
                {
                    return 0;
                }
                else
                {
                    try
                    {
                        return System.Convert.ToDouble(o);
                    }
                    catch (Exception)
                    {
                        return 0;
                    }
                }
            }
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
            public override object ProvideValue(IServiceProvider serviceProvider)
            {
                return this;
            }
        }
        public class GreaterThan : ComparisonConverter
        {
            protected override bool Compare(double a, double b)
            {
                return a > b;
            }
        }
    }
