    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace clock
    {
        /// <summary>
        /// Interaction logic for ctlClock.xaml
        /// </summary>
        public partial class ctlGauge : UserControl
        {
            public static DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(ctlGauge), new FrameworkPropertyMetadata(new PropertyChangedCallback(MaxValue_Changed)));
    
            public double MaxValue
            {
                get { return (double)GetValue(MaxValueProperty); }
                set { SetValue(MaxValueProperty, value); }
            }
    
    
            private static void MaxValue_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
            {
                ctlGauge thisClass = (ctlGauge)o;
                thisClass.SetMaxValue();
            }
    
            private void SetMaxValue()
            {
                MaxPointAngle = GetValueAngle(MaxValue);
            }
    
            public static DependencyProperty CurrentValueProperty = DependencyProperty.Register("CurrentValue", typeof(double), typeof(ctlGauge), new FrameworkPropertyMetadata(new PropertyChangedCallback(CurrentValue_Changed)));
    
            public double CurrentValue
            {
                get { return (double)GetValue(CurrentValueProperty); }
                set { SetValue(CurrentValueProperty, value); }
            }
    
    
            private static void CurrentValue_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
            {
                ctlGauge thisClass = (ctlGauge)o;
                thisClass.SetCurrentValue();
            }
    
            private void SetCurrentValue()
            {
                MainPointerAngle = GetValueAngle(CurrentValue);
            }
    
            public static DependencyProperty MainPointerAngleProperty = DependencyProperty.Register("MainPointerAngle", typeof(double), typeof(ctlGauge), new FrameworkPropertyMetadata(new PropertyChangedCallback(MainPointerAngle_Changed)));
    
            public static DependencyProperty MaxPointAngleProperty = DependencyProperty.Register("MaxPointAngle", typeof(double), typeof(ctlGauge), new FrameworkPropertyMetadata(new PropertyChangedCallback(MaxPointAngle_Changed)));
    
            public double MaxPointAngle
            {
                get { return (double)GetValue(MaxPointAngleProperty); }
                set { SetValue(MaxPointAngleProperty, value); }
            }
    
    
            private static void MaxPointAngle_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
            {
                ctlGauge thisClass = (ctlGauge)o;
                thisClass.SetMaxPointAngle();
            }
    
            private void SetMaxPointAngle()
            {
                //Put Instance MaxPointAngle Property Changed code here
            }
    
            public double MainPointerAngle
            {
                get { return (double)GetValue(MainPointerAngleProperty); }
                set { SetValue(MainPointerAngleProperty, value); }
            }
    
    
            private static void MainPointerAngle_Changed(DependencyObject o, DependencyPropertyChangedEventArgs args)
            {
                ctlGauge thisClass = (ctlGauge)o;
                thisClass.SetMainPointerAngle();
            }
    
            private void SetMainPointerAngle()
            {
                //Put Instance MainPointerAngle Property Changed code here
            }
    
            public ctlGauge()
            {
                InitializeComponent();
                SetCurrentValue();
                SetMaxValue();
            }
        
            private double GetValueAngle(double value)
            {
                double dAngle = 125 + (value * 29);
                if (dAngle > 360)
                {
                    dAngle -= 360;
                    if (dAngle > 56)
                        dAngle = 56;
                }
                else if (dAngle < 124)
                    dAngle = 124;
    
                return dAngle;
            }
        }
    }
