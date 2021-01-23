    using System;
    using System.Collections.Specialized;
    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            private NameValueCollection tourData = new NameValueCollection();
            private int currentIndex;
    
            public MainWindow()
            {
                InitializeComponent();
    
                tourData.Add("TextBox", "This is a TextBox");
                tourData.Add("Button", "This is a Button. You can click it");
                tourData.Add("CheckBox", "This is a CheckBox");
                tourData.Add("ComboBox", "This is a ComboBox. You can select an item");
    
            }
    
            private void MoveCallout(FrameworkElement element, string message)
            {
                GeneralTransform generaTransform = element.TransformToAncestor(this);
                Point point = generaTransform.Transform(new Point(0, 0));
    
                double x = point.X + element.ActualWidth + 4;
                double y = point.Y + element.ActualHeight + 4;
    
                CalloutMessage.Text = message;
                Callout.RenderTransform = new TranslateTransform(x, y);
            }
    
            private void StartTour(object sender, EventArgs args)
            {
                currentIndex = 0;
                Callout.Visibility = System.Windows.Visibility.Visible;
                Start.IsEnabled = false;
    
                FrameworkElement element = (FrameworkElement)FindName(tourData.GetKey(currentIndex));
                MoveCallout(element, tourData.Get(currentIndex));
    
                currentIndex++;
            }
    
            private void Ok(object sender, EventArgs args)
            {
                FrameworkElement element;
                if (currentIndex < tourData.Count)
                {
                    element = (FrameworkElement)FindName(tourData.GetKey(currentIndex));
                    MoveCallout(element, tourData.Get(currentIndex));
    
                    currentIndex++;
                }
                else
                {
                    Callout.Visibility = System.Windows.Visibility.Hidden;
                    Start.IsEnabled = true;
                }
    
            }
    
            private void Cancel(object sender, EventArgs args)
            {
                Callout.Visibility = System.Windows.Visibility.Hidden;
                Start.IsEnabled = true;
            }
        }
    }
