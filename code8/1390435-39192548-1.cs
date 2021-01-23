        <Window x:Class="WPFXamDataGrid.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                xmlns:mc="http://schemas.openxmlformats.org/markup-mpatibility/2006"
                xmlns:igDP="http://infragistics.com/DataPresenter"
                xmlns:local="clr-namespace:WPFXamDataGrid"
                mc:Ignorable="d"
                Title="MainWindow" Height="350" Width="525">
            <Grid>
                <igDP:XamDataGrid x:Name="xamDataGrid" Loaded="XamDataGrid_Loaded">
                    <igDP:XamDataGrid.FieldLayouts>
                        <igDP:FieldLayout>
                            <igDP:Field Name="Name"/>
                            <igDP:Field Name="Date"/>
                        </igDP:FieldLayout>
                    </igDP:XamDataGrid.FieldLayouts>
                </igDP:XamDataGrid>
            </Grid>
        </Window>
    
    
    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace WPFXamDataGrid
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
    
            private void XamDataGrid_Loaded(object sender, RoutedEventArgs e)
            {
                ObservableCollection<Item> list = new ObservableCollection<Item>();
    
                list.Add(new Item {Name = "First", Date = DateTime.Now});
                list.Add(new Item { Name = "Second", Date = ateTime.Now.AddDays(-1);
    
                xamDataGrid.DataSource = list;
            }
        }
    
        class Item
        {
            public string Name { get; set; }
            public DateTime Date { get; set; }
        }
    }
