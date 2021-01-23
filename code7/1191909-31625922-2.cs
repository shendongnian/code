    int ComboNO = 0;
    private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
    {
         ComboNO++;
         for (int i = 0; i < ComboCount; i++)
            if (ComboNO == i)
              foreach (FrameworkElement item in RootElement.Children)
                 if (item.Name == "comB" + i) item.Visibility = Visibility.Visible;
    }
