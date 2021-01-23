    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WPF_Demo
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            //This method handles the "Click to add new coins button"
            private void AddNewCoins(object sender, RoutedEventArgs e)
            {
                InputBox.Visibility = System.Windows.Visibility.Visible;
            }
            //This method handles input text entered by user
            int sum = 0;
            private void ClickToAddMoreCoins(object sender, RoutedEventArgs e)
            {
    
                //Hides InputBox and takes input text from user.
                InputBox.Visibility = System.Windows.Visibility.Collapsed;
    
                // Ensuring that input from user is a integer number
                String input = InputTextBox.Text;
                var result = 0;
                if (int.TryParse(input, out result))
                {
                    //Adding number of coins to CoinListBox
                    //CoinListBox.Items.Add(result);
                    //////////////////////////////////////////////////////////////////
    
                    //sum = CoinListBox.Items.Cast<object>().Sum(x => Convert.ToInt32(x));    
                    if (sum + result > 30)
                    {
                        //CoinListBox.Items.Add
                        MessageBoxResult answer = MessageBox.Show("You cannot enter more than 30 coins. Do you want to end?", "Message", MessageBoxButton.YesNo, MessageBoxImage.Question);
                        if (answer == MessageBoxResult.Yes)
                        {
                            Application.Current.Shutdown();
                        }
                    }
                    else
                    {
                        // Resets InputBox.
                        sum += result;
                        try
                        {
                            CoinListBox.Items.RemoveAt(0);
                        }
                        catch
                        { }
                        CoinListBox.Items.Add(sum);
                        //////////////////////////////////////////////////////////////////
                    }
                   
                }
                else
                {
                    MessageBox.Show("Please enter a number of coins");
                }
                InputTextBox.Text = String.Empty;
            }
            //This method hides InputBox.
            private void Cancel_Button_Click(object sender, RoutedEventArgs e)
            {
                //Hides InputBox.
                InputBox.Visibility = System.Windows.Visibility.Collapsed;
    
                // Resets InputBox.
                InputTextBox.Text = String.Empty;
            }
        }
    }
