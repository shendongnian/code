    using System;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            void Window_Loaded(object sender, RoutedEventArgs e)
            {
                //creating the button
                Button b = new Button() { Content = "Click me!" };
                //when clicked, it'll move to another row
                b.Click += (s, ea) => ChangeButtonRow(s as Button);
                //adding the button to the grid
                grdMain.Children.Add(b);
                //calling the row changing method for the 1st time, so the button will appear in a random row
                ChangeButtonRow(b);
            }
    
            void ChangeButtonRow(Button b)
            {
                //setting the Grid.Row dep. prop. to a number that's a valid row index
                b.SetValue(Grid.RowProperty, new Random().Next(0, grdMain.RowDefinitions.Count));
            }
        }
    }
