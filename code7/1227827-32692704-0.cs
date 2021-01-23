    <Window x:Class="WpfResources._32691328.Win32691328"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="Win32691328" Height="661.015" Width="506.391">
        <Window.Resources>
            <CollectionViewSource x:Key="vsmaster"  Source="{Binding Parts}"/>
            <CollectionViewSource x:Key="vsdetail1" Source="{Binding PARTIES_V1, Source={StaticResource vsmaster}}" />
        </Window.Resources>
        <StackPanel>
            <DataGrid x:Name="dataGridMaster" AutoGenerateColumns="True" EnableRowVirtualization="True" 
          ItemsSource="{Binding Source={StaticResource vsmaster}}"   
          RowDetailsVisibilityMode="VisibleWhenSelected"></DataGrid>
            <Button Content="UpdatePart" Click="Button_Click"/>
            <DataGrid x:Name="dataGridDetail1" Margin="0 10 0 0" IsReadOnly="True" SelectionMode="Single" AutoGenerateColumns="True" 
            	EnableRowVirtualization="True" 
            	ItemsSource="{Binding Source={StaticResource vsdetail1}}" IsSynchronizedWithCurrentItem="True" 
            	RowDetailsVisibilityMode="VisibleWhenSelected"/>
        </StackPanel>
    </Window>
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    
    namespace WpfResources._32691328
    {
        /// <summary>
        /// Interaction logic for Win32691328.xaml
        /// </summary>
        public partial class Win32691328 : Window
        {
            public Win32691328()
            {
                InitializeComponent();
    
                this.DataContext = new DataStore();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                List<PARTIES_V1> p = new List<PARTIES_V1>();
                p.Add(new PARTIES_V1() { ID = -1999 });
                p.Add(new PARTIES_V1() { ID = -1785 });
                p.Add(new PARTIES_V1() { ID = -1123 });
    
                ObservableCollection<Part> parts = (ObservableCollection<Part>)((ListCollectionView)dataGridMaster.ItemsSource).SourceCollection;
                parts[0].PARTIES_V1 = p;
    
                ((ListCollectionView)dataGridMaster.ItemsSource).Refresh();
            }
        }
    }
    using System;
    using System.Collections.ObjectModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace WpfResources._32691328
    {
        public class DataStore
        {
            ObservableCollection<Part> _parts;
            public ObservableCollection<Part> Parts { get { return _parts; } set { _parts = value; } }
    
            public DataStore() {
    
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
    
            public List<PARTIES_V1> PARTIES_V1 { get; set; }
        }
    
        public class PARTIES_V1
        {
    
            public int ID { get; set; }
        
        }
    }
