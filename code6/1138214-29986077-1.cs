	using System;
	using System.Collections.Generic;
	using System.Windows;
	namespace Demo
	{
		/// <summary>
		/// Interaction logic for MainWindow.xaml
		/// </summary>
		public partial class MainWindow : Window
		{
			public MainWindow()
			{
				InitializeComponent();
				List<DemoData> list = new List<DemoData>();
				for(int i = 0; i < 50; i++)
				{
					var data = new DemoData () {Name = "Data_HorzontallyLongData-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------Almost--------------------------------Done." + i};
					data.ChildrenList = new List<DemoData>();
					for(int j = 0; j < 15; j++)
					{
						data.ChildrenList.Add(new DemoData() { Name = "Children_"+ i +"_"+ j});
					}
					list.Add(data);
				}
				TV.ItemsSource = list;
			}
		}
		public class DemoData
		{
			public List<DemoData> ChildrenList { get; set; }
			public String Name { get; set; }
			
		}
	}
