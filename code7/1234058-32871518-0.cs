    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="524.627" Width="862.313">
        <StackPanel>
            <DataGrid x:Name="Dgrd" HorizontalAlignment="Left" Margin="10,10,0,0" VerticalAlignment="Top" AutoGenerateColumns="False">
                <DataGrid.Columns>
                    <DataGridTextColumn Binding="{Binding Value.Status.Name}" ClipboardContentBinding="{x:Null}" Header="Status"/>
                </DataGrid.Columns>
            </DataGrid>
            <Button Content="Button" HorizontalAlignment="Left" Margin="29,38,0,0" Grid.Row="1" VerticalAlignment="Top" Width="75" Click="Button_Click"/>
    
        </StackPanel>
    </Window>
    using System;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
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
    
                Dgrd.ItemsSource = DataStore.Operations;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                DataStore.Operations[0].Value.Status.Name = "N/A"; // change first item
            }
        }
    
        public class DataStore
        {
            //static List<Operation> _operations;
            public static List<Operation> Operations;
    
            static DataStore()
            {
                Operations =
                    new List<Operation>() { 
                        new Operation(){ Value = new RecordInner(){ Status = new OverallStatus (){ Name="Pending"}}},
                        new Operation(){ Value = new RecordInner(){ Status = new OverallStatus (){ Name="Started"}}},
                        new Operation(){ Value = new RecordInner(){ Status = new OverallStatus (){ Name="Completed"}}}
                    };
            }
    
        }
    
        public class Operation
        {
            RecordInner _value;
            public RecordInner Value
            {
                get { return _value; }
                set { _value = value; }
            }
        }
    
        public class RecordInner
        { 
            OverallStatus _status;
            public OverallStatus Status
            {
                get { return _status; }
                set { _status = value; }
            }
        }
    
        public class OverallStatus:INotifyPropertyChanged
        {
            string _name;
            public string Name { get { return _name; } set { _name = value; OnPropertyChanged("name"); } }
    
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(string name)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    
    }
