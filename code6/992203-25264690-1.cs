    using System;
    using System.Windows;
    using System.Windows.Controls;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow() {
                InitializeComponent();
            }
            private void comboSelectChanged(object sender, SelectionChangedEventArgs e) {
                textBox1.Text = comboBox1.SelectedItem.ToString();
                textBox2.Text = comboBox1.Text;
                textBox3.Text = comboBox1.SelectedIndex.ToString();
                textBox4.Text = comboBox1.SelectedValue.ToString();
                textBox5.Text = (comboBox1.SelectedItem as ComboBoxItem).Content as string;  
             }
            private void btnSelect_Click(object sender, RoutedEventArgs e) {
                // Winform working code:  comboBox1.SelectedIndex = comboBox1.FindString("string");
                // WPF - This REQUIRES "SelectedValuePath="Content"" in XAML combobox def.
                comboBox1.SelectedValue = "Three";
            }
        }
    }
