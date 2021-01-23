    <Window x:Class="WpfResources._32691328.Win32691328"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Win32691328" Height="661.015" Width="506.391">
    
      <StackPanel>
        <DataGrid x:Name="dataGridMaster" AutoGenerateColumns="True" EnableRowVirtualization="True"                    
                RowDetailsVisibilityMode="VisibleWhenSelected" />
        <Button Content="UpdatePart" Click="Button_Click"/>
        <DataGrid x:Name="dataGridDetail" Margin="0 10 0 0" IsReadOnly="True" SelectionMode="Single" AutoGenerateColumns="True" 
        	EnableRowVirtualization="True" 
        	 IsSynchronizedWithCurrentItem="True" 
        	RowDetailsVisibilityMode="VisibleWhenSelected"/>
       </StackPanel>    
    </Window>
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    
    namespace WpfResources._32691328
    {
        /// <summary>
        /// Interaction logic for Win32691328.xaml
        /// </summary>
        public partial class Win32691328 : Window
        {
            DataStore d;
            
            public Win32691328()
            {
                InitializeComponent();
    
                d = new DataStore();
                this.DataContext = d;
                
                // Bind ItemsSource of both Grids
    
                Binding bi1 = new Binding();
                bi1.Source = d.PartsView;
                bi1.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(dataGridMaster, DataGrid.ItemsSourceProperty, bi1);
                
                Binding bi2 = new Binding();
                bi2.Source = d.PartiesDetailView;
                bi2.Mode = BindingMode.OneWay;
                BindingOperations.SetBinding(dataGridDetail, DataGrid.ItemsSourceProperty, bi2);
            }
            
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                d.Change();           
            }
        }
    }
    using System;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Windows.Data;
    
    namespace WpfResources._32691328
    {
        public class DataStore
        {
            ObservableCollection<Part> _parts;
            public ObservableCollection<Part> Parts { get { return _parts; } set { _parts = value; } }
    
            CollectionViewSource _partsViewMaster;
            public CollectionViewSource PartsView
            {
                get { return _partsViewMaster; }
            }
    
            CollectionViewSource _partsDetailView;
            public CollectionViewSource PartiesDetailView
            {
                get { return _partsDetailView; }
            }
    
            public DataStore() {
    
                _partsViewMaster = new CollectionViewSource();
                _partsDetailView = new CollectionViewSource();          
    
                List<PARTIES_V1> p1 = new List<PARTIES_V1>();
                p1.Add(new PARTIES_V1() { ID = 1999 });
                p1.Add(new PARTIES_V1() { ID = 1785 });
                p1.Add(new PARTIES_V1() { ID = 1123 });
    
                List<PARTIES_V1> p2 = new List<PARTIES_V1>();
                p2.Add(new PARTIES_V1() { ID = 289 });
                p2.Add(new PARTIES_V1() { ID = 2644 });
                p2.Add(new PARTIES_V1() { ID = 2321 });
    
                List<PARTIES_V1> p3 = new List<PARTIES_V1>();
                p3.Add(new PARTIES_V1() { ID = 3754 });
                p3.Add(new PARTIES_V1() { ID = 37543 });
                p3.Add(new PARTIES_V1() { ID = 31333 });
                
                _parts = new ObservableCollection<Part>();
                _parts.Add(new Part(1, "123", "1abc", 111, p1));
                _parts.Add(new Part(5, "3453", "2abc", 111, p2));
                _parts.Add(new Part(7, "13433", "3abc", 111, p3));
                _parts.Add(new Part(8, "2223", "4abc", 111, p1));
                _parts.Add(new Part(10, "155553", "5abc", 111, p3));
                _parts.Add(new Part(11, "122223", "6abc", 111, p2));
    
    
                Binding bc1 = new Binding("Parts");
                bc1.Source = this;
                BindingOperations.SetBinding(_partsViewMaster, CollectionViewSource.SourceProperty, bc1);
    
                Binding bc2 = new Binding("PARTIES_V1");
                bc2.Source = _partsViewMaster;
                BindingOperations.SetBinding(_partsDetailView, CollectionViewSource.SourceProperty, bc2);
            }
    
            public void Change()
            {
                // Do some changes
    
                List<PARTIES_V1> p = new List<PARTIES_V1>();
                p.Add(new PARTIES_V1() { ID = -1999 });
                p.Add(new PARTIES_V1() { ID = -1785 });
                p.Add(new PARTIES_V1() { ID = -1123 });
    
                _parts[0].PARTIES_V1 = p;
    
                // recreate view
                _partsViewMaster.View.Refresh();
            }
        }
    
        public class Part
        {
            public Part(int id, string pnumber, string owner, int? priceid,
                List<PARTIES_V1> lparties)
            {
                ID = id;
                PART_NUMBER = pnumber;
                OWNER = owner;
                PRICE_ID = priceid;
                PARTIES_V1 = lparties;
            }
            public int ID { get; set; }
    
            public string PART_NUMBER { get; set; }
    
            public string OWNER { get; set; }
    
            public int? PRICE_ID { get; set; }
    
            List<PARTIES_V1> _parties = new List<PARTIES_V1>();
            public List<PARTIES_V1> PARTIES_V1 { get { return _parties; } set { _parties = value; } }
    
        }
    
        public class PARTIES_V1
        {
    
            public int ID { get; set; }
        
        }
    }
