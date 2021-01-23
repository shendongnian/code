    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApplication1
    {
    public partial class UserControl1 : UserControl
    {
        private readonly List<Border> redBorders = new List<Border>();
        private readonly List<Border> greenBorders = new List<Border>();
        public UserControl1()
        {
            InitializeComponent();
            myListbox.ItemsSource = new List<string>() { "Batman", "Superman",     "All others" };
        }
        private void RedBorder_OnLoaded(object sender, RoutedEventArgs e)
        {
            redBorders.Add(sender as Border);
        }
        private void GreenBorder_OnLoaded(object sender, RoutedEventArgs e)
        {
            greenBorders.Add(sender as Border);
        }
        private void FirstButton_OnClick(object sender, RoutedEventArgs e)
        {
            redBorders.ForEach(p => p.Visibility = Visibility.Visible);
            greenBorders.ForEach(p => p.Visibility = Visibility.Collapsed);
        }
        private void SecondButton_OnClick(object sender, RoutedEventArgs e)
        {
            redBorders.ForEach(p => p.Visibility = Visibility.Collapsed);
            greenBorders.ForEach(p => p.Visibility = Visibility.Visible);
        }
    }
    }
