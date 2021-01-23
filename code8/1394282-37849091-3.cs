    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace WpfAnimation
    {
        /// <summary>
        /// Interaction logic for Window2.xaml
        /// </summary>
        public partial class Window2 : Window
        {
            public Window2()
            {
                InitializeComponent();
            }
            
    
            public static double GetMovingObjectPos(DependencyObject obj)
            {
                return (double)obj.GetValue(MovingObjectPosProperty);
            }
    
            public static void SetMovingObjectPos(DependencyObject obj, double value)
            {
                obj.SetValue(MovingObjectPosProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for MovingObject.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty MovingObjectPosProperty =
                DependencyProperty.RegisterAttached("MovingObjectPos", typeof(double), typeof(Window2), new PropertyMetadata(0.0, new PropertyChangedCallback(MovingObjectPosChanged)));
    
    
            private static void MovingObjectPosChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
     	        double leftOfMovingObject = (double) e.NewValue ;
                Path beam = (Path) d;
    
                System.Diagnostics.Debug.WriteLine("Left = " + e.NewValue.ToString());
    
                double leftOfBeam = Canvas.GetLeft(beam);
                double widthOfBeam = 20.0;
    
                if (leftOfMovingObject > leftOfBeam && leftOfMovingObject < leftOfBeam + widthOfBeam)
                {
                    System.Diagnostics.Debug.WriteLine("Hit >>>>> = " + e.NewValue.ToString());
    
                    beam.Fill = Brushes.Gray;
                }
            }
                    
            
        }
    }
