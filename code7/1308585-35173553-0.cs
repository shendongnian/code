     public static System.Windows.Controls.Image fromControlToImage(System.Windows.FrameworkElement control)
     {
        Size size = new Size(100, 100); // Or what ever size you want...
        control.Measure(size);
        control.Arrange(new Rect(size));
        control.UpdateLayout();
        ...
     }
