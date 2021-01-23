	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows;
	namespace WpfApplication1
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
			}
			private void Window_Activated(object sender, EventArgs e)
			{
				var items = new List<string>();
				for (var i = 0; i < 10; i++)
				{
					items.Add("Item" + i);
				}
				comboBox.ItemsSource = items;
				comboBox.SelectedItem = "Item0";
			}
			private void button_Click(object sender, RoutedEventArgs e)
			{
				comboBox.SelectedItem = "Item5";
			}
			private void button1_Click(object sender, RoutedEventArgs e)
			{
				comboBox.SelectedItem = "Item9";
			}
		}
	}
