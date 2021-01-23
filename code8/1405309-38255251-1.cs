    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using Windows.UI.Xaml.Controls;
    
    // The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409
    
    namespace App1
    {
        /// <summary>
        /// An empty page that can be used on its own or navigated to within a Frame.
        /// </summary>
        public sealed partial class MainPage : Page, INotifyPropertyChanged
        {
            public ObservableCollection<DummyData> DummyData { get; set; }
            private DummyData tempSelectedItem;
    
            public MainPage()
            {
                DummyData = new ObservableCollection<DummyData>();
    
                DummyData.Add(new DummyData()
                {
                    Adress = "London",
                    FirstName = "Shella",
                    LastName = "Schranz",
                    ShowDetails = false
                });
    
                DummyData.Add(new DummyData()
                {
                    Adress = "New York",
                    FirstName = "Karyl",
                    LastName = "Lotz",
                    ShowDetails = false
                });
    
                DummyData.Add(new DummyData()
                {
                    Adress = "Pasadena",
                    FirstName = "Jefferson",
                    LastName = "Kaur",
                    ShowDetails = false
                });
    
                DummyData.Add(new DummyData()
                {
                    Adress = "Berlin",
                    FirstName = "Soledad",
                    LastName = "Farina",
                    ShowDetails = false
                });
    
                DummyData.Add(new DummyData()
                {
                    Adress = "Brazil",
                    FirstName = "Cortney",
                    LastName = "Mair",
                    ShowDetails = false
                });
    
                this.InitializeComponent();
    
                lvDummyData.ItemsSource = DummyData;
            }
    
            private void lvDummyData_ItemClick(object sender, ItemClickEventArgs e)
            {
                DummyData selectedItem = e.ClickedItem as DummyData;
    
                selectedItem.ShowDetails = true;
    
                if (tempSelectedItem != null)
                {
                    tempSelectedItem.ShowDetails = false;
                    selectedItem.ShowDetails = true;
                }
    
                tempSelectedItem = selectedItem;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void RaisePropertyChangeEvent(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    
        public class DummyData : INotifyPropertyChanged
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Adress { get; set; }
    
            private bool showDetails;
    
            public bool ShowDetails
            {
                get
                {
                    return showDetails;
                }
                set
                {
                    showDetails = value;
                    RaisePropertyChangeEvent(nameof(ShowDetails));
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void RaisePropertyChangeEvent(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
