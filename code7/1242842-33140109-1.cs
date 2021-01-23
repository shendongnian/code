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
      using System.Collections.ObjectModel;
     namespace AutoScrollListBox
    {
    public partial class MainWindow : Window
    {
        ObservableCollection<EquipmentItem> m_selectedEquipmentHorizontal = new ObservableCollection<EquipmentItem>();
        ObservableCollection<EquipmentItem> m_selectedEquipmentVertical = new ObservableCollection<EquipmentItem>();
        public MainWindow()
        {
            InitializeComponent();
        }
        protected override void OnInitialized( EventArgs e )
        {
            base.OnInitialized( e );
            ObservableCollection<EquipmentItem> equipmentList1 = new ObservableCollection<EquipmentItem>();
            this.horizontalListBox.ItemsSource = equipmentList1;
            CreateEquipments( equipmentList1, "Tank-" );
            this.horizontalSelectedItemsListBox.ItemsSource = m_selectedEquipmentHorizontal;
            ObservableCollection<EquipmentItem> equipmentList2 = new ObservableCollection<EquipmentItem>();
            this.verticalListBox.ItemsSource = equipmentList2;
            CreateEquipments( equipmentList2, "Tank-" );
            this.verticalSelectedItemsListBox.ItemsSource = m_selectedEquipmentVertical;
        }
        private ObservableCollection<EquipmentItem> CreateEquipments( ObservableCollection<EquipmentItem> equipmentList, string prefix )
        {
            int maxItemCount = 20;
            for( int i = 0; i < maxItemCount; i++ )
            {
                equipmentList.Add( new EquipmentItem() { Name = prefix + i.ToString(), CampaignName = "Batch_ " + i.ToString() } );
            }
            return equipmentList;
        }
        private void horizontalListBox_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            if( e.AddedItems.Count > 0 )
            {
                foreach( EquipmentItem item in e.AddedItems )
                {
                    m_selectedEquipmentHorizontal.Add( item );
                }
            }
            if( e.RemovedItems.Count > 0 )
            {
                foreach( EquipmentItem item in e.RemovedItems )
                {
                    m_selectedEquipmentHorizontal.Remove( item );
                }
            }
        }
        private void verticalListBox_SelectionChanged( object sender, SelectionChangedEventArgs e )
        {
            if( e.AddedItems.Count > 0 )
            {
                foreach( EquipmentItem item in e.AddedItems )
                {
                    m_selectedEquipmentVertical.Add( item );
                }
            }
            if( e.RemovedItems.Count > 0 )
            {
                foreach( EquipmentItem item in e.RemovedItems )
                {
                    m_selectedEquipmentVertical.Remove( item );
                }
            }
        }
        }
      }
