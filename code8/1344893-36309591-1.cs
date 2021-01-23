    private void SchematbazyNorthwind_Click(object sender, RoutedEventArgs e)
            {
                StackPanel stackPanel = null;
                using (FileStream fs =
                new FileStream("Dictionary1.xaml", FileMode.Open, FileAccess.Read))
                {
                    stackPanel = (StackPanel)XamlReader.Load(fs);
                }
                MainGrid.Children.Add(stackPanel);
            }
