    public class MyLabel : Label
    {
        public static readonly DependencyProperty MyCaptionProperty =
            DependencyProperty.Register("MyCaption ",
                                        typeof(string),
                                        typeof(MyLabel), new FrameworkPropertyMetadata(string.Empty, OnChangedCallback));
        public string MyCaption
        {
            get { return (string)GetValue(MyCaptionProperty); }
            set { SetValue(MyCaptionProperty, value); }
        }
        private static void OnChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var labelControl = d as Label;
            if (labelControl != null)
                labelControl.Content = e.NewValue;
        }
    }
    <Window x:Class="WpfTestProj.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:wpfTestProj="clr-namespace:WpfTestProj"        
        Title="MainWindow" Height="350" Width="525">
    <wpfTestProj:MyLabel MyCaption="This is a test" />
