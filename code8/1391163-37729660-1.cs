    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:WpfApplication1"
            mc:Ignorable="d"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <DataGrid x:Name="MyDataGrid"
                      LostFocus="DataGrid_LostFocus" 
                      ItemsSource="{Binding Persons}">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="FirstName" Width="*"/>
                    <DataGridTextColumn Header="LastName" Width="*"/>
                </DataGrid.Columns>
            </DataGrid>
    
            <TextBox Grid.Column="1"/>
        </Grid>
    </Window>
    namespace WpfApplication1
    {
        using System.Collections.Generic;
        using System.Windows;
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public List<Person> Persons { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                Persons = new List<Person>
                {
                    new Person { FirstName = "First", LastName = "Last" },
                    new Person { FirstName = "First", LastName = "Last" }
                };
            }
    
            private void DataGrid_LostFocus(object sender, RoutedEventArgs e)
            {
                if (!MyDataGrid.IsKeyboardFocusWithin)
                {
                    MessageBox.Show("DataGrid LostFocus called");
                }
            }
        }
    
        public class Person
        {
            public string FirstName { get; set; }
    
            public string LastName { get; set; }
        }
    }
