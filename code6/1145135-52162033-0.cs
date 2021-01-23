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
        
        namespace WpfApplication1
        {
            /// <summary>
            /// Interaction logic for MainWindow.xaml
            /// </summary>
            public partial class MainWindow : Window
            {
                Dictionary<int, System.Windows.Ink.Stroke> myStrokes;
                public MainWindow()
                {
                    InitializeComponent();
                    myStrokes = new Dictionary<int, System.Windows.Ink.Stroke>();
                    this.WindowState = System.Windows.WindowState.Maximized;
                    SandyCanvas.TouchDown += SandyCanvas_OnTouchDown;
                    SandyCanvas.TouchUp += SandyCanvas_OnTouchUp;
                    SandyCanvas.TouchMove += SandyCanvas_OnTouchMove;
                }
                private void SandyCanvas_OnTouchMove(object sender, TouchEventArgs e)
                {
                    var touchPoint = e.GetTouchPoint(this);
                    var point = touchPoint.Position;
        
                    if (myStrokes.ContainsKey(touchPoint.TouchDevice.Id))
                    {
                        var stroke = myStrokes[touchPoint.TouchDevice.Id];
                        var nearbyPoint = CheckPointNearby(stroke, point);
                        if (!nearbyPoint)
                        {
                            stroke.StylusPoints.Add(new StylusPoint(point.X, point.Y));
                        }
                    }
                }
                private static bool CheckPointNearby(System.Windows.Ink.Stroke stroke, Point point)
                {
                    return stroke.StylusPoints.Any(p => (Math.Abs(p.X - point.X) <= 1) && (Math.Abs(p.Y - point.Y) <= 1));                
                }
                private void SandyCanvas_OnTouchUp(object sender, TouchEventArgs e)
                {
                    var touchPoint = e.GetTouchPoint(this);
                    myStrokes.Remove(touchPoint.TouchDevice.Id);
                }        
                private void SandyCanvas_OnTouchDown(object sender, TouchEventArgs e)
                {
                    var touchPoint = e.GetTouchPoint(this);
                    var point = touchPoint.Position;
                    System.Windows.Ink.Stroke newStroke = new System.Windows.Ink.Stroke(new StylusPointCollection(new List<Point> { point }), SandyCanvas.DefaultDrawingAttributes);
                    if (!myStrokes.ContainsKey(touchPoint.TouchDevice.Id))
                    {
                        myStrokes.Add(touchPoint.TouchDevice.Id, newStroke);
                        SandyCanvas.Strokes.Add(newStroke);
                    }
                }
            }
        }
    
    /////////////////////Designer Page////////////////////
    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <InkCanvas x:Name="SandyCanvas"></InkCanvas>
        </Grid>
    </Window>
