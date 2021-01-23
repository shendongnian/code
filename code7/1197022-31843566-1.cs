    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    
    namespace CollapsingListViewItemContainers
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public ObservableCollection<Car> _cars = new ObservableCollection<Car>
                            {
                                new Car("Not yours", "Mine", 1),
                                new Car("Not mine", "Yours", 2),
                                new Car("Not ours", "His", 3),
                                new Car("Not ours", "Hers", 4),
                            };
            public ObservableCollection<Car> Cars
            {
                get
                {
                    return _cars;
                }
            }
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                Cars[2].IsVisible = !Cars[2].IsVisible;
            }
        }
    
        public class Car : INotifyPropertyChanged
        {
            private bool _isVisible;
            public bool IsVisible
            {
                get
                {
                    return _isVisible;
                }
                set
                {
                    _isVisible = value;
                    NotifyPropertyChanged("IsVisible");
                }
            }
            public string Name
            {
                get; set;
            }
    
            public string Title
            {
                get; set;
            }
    
            public int Id
            {
                get; set;
            }
    
            public Car(string name, string title, int id)
            {
                Name = name;
                Title = title;
                Id = id;
                IsVisible = true;
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            public void NotifyPropertyChanged(string propertyName)
            {
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
