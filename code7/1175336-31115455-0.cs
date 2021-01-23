        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowUserControl1().Begin();
        }
        private Storyboard ShowUserControl1()
        {
            // var control1 = new uc1(); uncomment it if the control does not exist
            control1.RenderTransform = new TranslateTransform();
            Root.Children.Add(im);
            // Root is your root container. In this case - Grid
            // and you have to add it only in the case if it does not exists
            Storyboard sb = new Storyboard();
            DoubleAnimation slide = new DoubleAnimation();
            slide.To = 0;
            slide.From = Root.ActualWidth;
            slide.Duration = new Duration(TimeSpan.FromMilliseconds(400));
            // Set the target of the animation
            Storyboard.SetTarget(slide, control1);
            Storyboard.SetTargetProperty(slide, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
            // Kick the animation off
            sb.Children.Add(slide);
            return sb;
        }
