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
    using HelixToolkit.Wpf;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }              
    
            public void geometry()
            {
                canvas4.Children.Clear();
                double one, two, three, four, ang, ang2, x1, x2, x3, x4, y1, y2, y3, y4, Rads;
                if (double.TryParse(txtOne.Text, out one))
                    if (double.TryParse(txtTwo.Text, out two))
                        if (double.TryParse(txtThree.Text, out three))
                            if (double.TryParse(txtFour.Text, out four))
                                if (double.TryParse(txtAngle.Text, out ang))
                                    if (double.TryParse(txtAngle.Text, out ang2))
    
    
                if (double.TryParse(txtAngle.Text, out ang))
                    if (double.TryParse(txtAngle.Text, out ang2))
                    {
                        RotateTransform ans2 = new RotateTransform();
                        ans2.Angle = ang2;
                        ans2.CenterX = 180;
                        ans2.CenterY = 180;
    
                        if (ang2 < 0)
                        {
                            ang2 = (360 + ang);
                        }
    
                        Rads = Math.PI * ang / 180;
    
                        x1 = Math.Sin(Rads) * 50;
                        y1 = Math.Cos(Rads) * 50;
                        x2 = Math.Sin(Rads) * 160;
                        y2 = Math.Cos(Rads) * 160;
                        x3 = Math.Sin(Rads) * 50;
                        y3 = Math.Cos(Rads) * 50;
                        x4 = Math.Sin(Rads) * 160;
                        y4 = Math.Cos(Rads) * 160;
                    
                        Line lineW = new Line();
                        lineW.Stroke = Brushes.Black;
                        lineW.StrokeThickness = 1.5;
                        lineW.X1 = 180;
                        lineW.Y1 = 15;
                        lineW.X2 = 180;
                        lineW.Y2 = 340;
                        lineW.HorizontalAlignment = HorizontalAlignment.Center;
                        lineW.VerticalAlignment = VerticalAlignment.Center;
                        lineW.RenderTransform = ans2;
                        canvas4.Children.Add(lineW);
    
                        Line lineY = new Line();
                        lineY.Stroke = Brushes.Black;
                        lineY.StrokeThickness = 1.5;
                        lineY.X1 = 180;
                        lineY.Y1 = 20;
                        lineY.X2 = 180;
                        lineY.Y2 = 340;
                        lineY.HorizontalAlignment = HorizontalAlignment.Center;
                        lineY.VerticalAlignment = VerticalAlignment.Center;              
                        canvas4.Children.Add(lineY);
    
                        Line lineZ = new Line();
                        lineZ.Stroke = Brushes.Black;
                        lineZ.StrokeThickness = 1.5;
                        lineZ.X1 = 20;
                        lineZ.Y1 = 180;
                        lineZ.X2 = 340;
                        lineZ.Y2 = 180;
                        lineZ.HorizontalAlignment = HorizontalAlignment.Center;
                        lineZ.VerticalAlignment = VerticalAlignment.Center;                   
                        canvas4.Children.Add(lineZ);
    
                        Ellipse ell6 = new Ellipse();
                        ell6.Width = 10;
                        ell6.Height = 10;
                        ell6.Stroke = Brushes.Black;
                        ell6.Fill = Brushes.LimeGreen;              
                        
                        TranslateTransform ell66 = new TranslateTransform(175+x2, 175-y2);
                        ell6.RenderTransform = ell66;                  
                        canvas4.Children.Add(ell6);
    
                        Ellipse ell7 = new Ellipse();
                        ell7.Width = 10;
                        ell7.Height = 10;
                        ell7.Stroke = Brushes.Black;
                        ell7.Fill = Brushes.Yellow;
                        TranslateTransform ell77 = new TranslateTransform(175 + x1,175- y1);
                        ell7.RenderTransform = ell77;
                        canvas4.Children.Add(ell7);
    
                        Ellipse ell8 = new Ellipse();
                        ell8.Width = 10;
                        ell8.Height = 10;
                        ell8.Stroke = Brushes.Black;
                        ell8.Fill = Brushes.Yellow;
                        TranslateTransform ell88 = new TranslateTransform(175 - x2, 175 + y2);
                        ell8.RenderTransform = ell88;
                        canvas4.Children.Add(ell8);
    
                        Ellipse ell9 = new Ellipse();
                        ell9.Width = 10;
                        ell9.Height = 10;
                        ell9.Stroke = Brushes.Black;
                        ell9.Fill = Brushes.Yellow;
                        TranslateTransform ell99 = new TranslateTransform(175 - x1, 175 + y1);
                        ell9.RenderTransform = ell99;
                        canvas4.Children.Add(ell9);
    
                        PathGeometry pathGeometry = new PathGeometry();
                        PathFigure figure = new PathFigure();
                        figure.StartPoint = new Point(180, 20);
                        figure.Segments.Add(new ArcSegment(new Point(180 + x2, 180 - y2), new Size(320, 320), ang2, false, SweepDirection.Clockwise, true));                    
                      
    
                        pathGeometry.Figures.Add(figure);
                        Path path = new Path();
                        path.Data = pathGeometry;
                        //path.Fill = Brushes.Pink;
                        path.Stroke = Brushes.Red;
                        canvas4.Children.Add(path);                    
                    }
            }
    
              
                                      
            private void btnTest_Click(object sender, RoutedEventArgs e)
            {           
                geometry();           
            }
               
            }
        }
