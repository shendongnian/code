     private void Btn1_Click(object sender, RoutedEventArgs e)
        {
            Button button = new Button(); button.Background = Brushes.Red;
            button.Width = 70; button.Height = 20;
            Canvas.SetLeft(button, 100); Canvas.SetTop(button, 120);
            button.Padding = new Thickness(1);
            StackPanel stackPanel = new StackPanel();
            Viewbox viewBox = new Viewbox();
            viewBox.ClipToBounds = false;
            Canvas canvas = new Canvas();
           // canvas.Width = button.Width; canvas.Height = button.Height;
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "this is a test";
            textBlock.FontSize = 15;
            textBlock.FontFamily = new FontFamily("Arial");
            textBlock.TextWrapping = TextWrapping.NoWrap;
            textBlock.Foreground = Brushes.Green;
            textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            textBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            viewBox.Height = 20;
            textBlock.IsHitTestVisible = false;
            stackPanel.Children.Add(canvas);
            viewBox.Child = textBlock;
            canvas.Children.Add(viewBox);
            button.Content = stackPanel;
            Canvas MainCanvas = new Canvas();
            MainCanvas.Children.Add(button);
            this.Content = MainCanvas;
        }
