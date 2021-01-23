    <Window x:Class="WpfDataControls.DataGrid._32792409.Win32792409"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="Win32792409" Height="329.323" Width="568.421">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="192*"/>
                <RowDefinition Height="107*"/>
            </Grid.RowDefinitions>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="87*"/>
                <ColumnDefinition Width="53*"/>
            </Grid.ColumnDefinitions>
            <DataGrid x:Name="DgrdEmployees"  PreviewMouseDown="Grid_PreviewMouseDown" HorizontalAlignment="Left" Margin="29,30,0,0" VerticalAlignment="Top" Height="148" Width="305" LoadingRow="DgrdEmployees_LoadingRow" />
            <TextBox x:Name="TbDgrdCellContent" Visibility="Hidden" Width="200" Height="100" HorizontalAlignment="Left" Margin="44,59,0,0" TextWrapping="Wrap" VerticalAlignment="Top" Background="#FFFFF3F3" BorderThickness="4"/>
        </Grid>
    </Window>
    using System;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Data;
    using System.Diagnostics;
    
    using System.Windows.Media;
    
    namespace WpfDataControls.DataGrid._32792409
    {
        /// <summary>
        /// Interaction logic for Win32792409.xaml
        /// </summary>
        public partial class Win32792409 : Window
        {
            public Win32792409()
            {
                InitializeComponent();
    
                ICollectionView view = CollectionViewSource.GetDefaultView(DataStore.Employees);
                DgrdEmployees.ItemsSource = view;
            }
    
            private void Grid_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                TbDgrdCellContent.Visibility = System.Windows.Visibility.Hidden;            
            }
    
            private void DgrdEmployees_LoadingRow(object sender, DataGridRowEventArgs e)
            {
                MouseButtonEventHandler handler = new MouseButtonEventHandler(DgrdCell_MouseDoubleClick);
                e.Row.AddHandler(DataGridCell.MouseDoubleClickEvent, handler);
            }
    
            private void DgrdCell_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
            {
                Debug.WriteLine("Double click");
    
                DataGridCellInfo cellInfo = DgrdEmployees.CurrentCell;
                DataGridColumn col = cellInfo.Column;
                if (DgrdEmployees.Columns.IndexOf(col) < DgrdEmployees.Columns.Count - 1) return;
    
                FrameworkElement content = col.GetCellContent(cellInfo.Item);
    
                TbDgrdCellContent.Visibility = System.Windows.Visibility.Visible;
                TbDgrdCellContent.Text = ((TextBox)content).Text;
                TbDgrdCellContent.Focus();
            }
    
        }
    
        public class DataStore
        {
            static ObservableCollection<Employee> _employees;
            public static ObservableCollection<Employee> Employees { get { return _employees; } set { _employees = value; } }
    
            static DataStore() {
                _employees = new ObservableCollection<Employee>();
                _employees.Add(new Employee() { Name = "Anjum", Address = "nizamuddin" });
                _employees.Add(new Employee() { Name = "Ashok", Address = "bharat nagar" });
                _employees.Add(new Employee() { Name = "BAshok", Address = "bharat nagar" });
                _employees.Add(new Employee() { Name = "DAshok", Address = "bharat nagar" });
                _employees.Add(new Employee() { Name = "TAshok", Address = "bharat nagar" });
                _employees.Add(new Employee() { Name = "GAshok", Address = "bharat nagar" });
    
            }
    
        }
    
        public class Employee {
    
            public String Name { get; set; }
            public String Address { get; set; }        
    
        }
    }
