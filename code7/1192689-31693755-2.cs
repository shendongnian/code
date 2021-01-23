    public class MyScrollBar : ScrollBar
    {
        static MyScrollBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MyScrollBar), new FrameworkPropertyMetadata(typeof(MyScrollBar)));
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var canvas = Template.FindName("PART_Canvas", this) as Canvas;
            if (canvas != null)
            {
                //draw something onto the canvas
                Line myLine = new Line();
                myLine.Stroke = System.Windows.Media.Brushes.Red;
                myLine.X1 = 100;
                myLine.X2 = 140;  
                myLine.Y1 = 200;
                myLine.Y2 = 200;
                myLine.StrokeThickness = 1;
                canvas.Children.Add(myLine);
            }
        }
    }
