    using System;
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
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace CalloutControl
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                var vm = new MainWindowViewModel();
    
                vm.Groups.Add(new CalloutControl.CalloutGroup(2));
                vm.Groups.Add(new CalloutControl.CalloutGroup(2));
    
                vm.Groups[0].Group.Add(new CalloutControl.CalloutItem(10, 1, 0, 100, 200, 100));
                vm.Groups[0].Group.Add(new CalloutControl.CalloutItem(10, 2, 100, 0, 100, 200));
    
                vm.Groups[1].Group.Add(new CalloutControl.CalloutItem(10, 1, 100, 0, 200, 100));
                vm.Groups[1].Group.Add(new CalloutControl.CalloutItem(10, 2, 100, 200, 200, 100));
    
                DataContext = vm;
            }
        }
    }
    namespace CalloutControl
    {
        public class CalloutItem : INotifyPropertyChanged
        {
            public CalloutItem()
            {
    
            }
            public CalloutItem(int length,
                       int itemNum,
                         double _x1,
                        double _y1,
                double _x2,
                double _y2)
            {
                Length = length;
                ItemNum = itemNum;
                X1 = _x1;
                Y1 = _y1;
                X2 = _x2;
                Y2 = _y2;
            }
            private int length;
    
            public int Length
            {
                get { return length; }
                set
                {
                    length = value;
                    OnPropertyChanged("Length");
                }
            }
            private int itemNum;
    
            public int ItemNum
            {
                get { return itemNum; }
                set
                {
                    itemNum = value;
                    OnPropertyChanged("ItemNum");
                }
            }
            //public int      ItemNum;
            private double x1;
            public double X1
            {
                get { return x1; }
                set
                {
                    x1 = value;
                    OnPropertyChanged("X1");
                }
            }
            private double y1;
            public double Y1
            {
                get { return y1; }
                set
                {
                    y1 = value;
                    OnPropertyChanged("Y1");
                }
            }
    
            private double x2;
            public double X2
            {
                get { return x2; }
                set
                {
                    x2 = value;
                    OnPropertyChanged("X2");
                }
            }
            private double y2;
            public double Y2
            {
                get { return y2; }
                set
                {
                    y2 = value;
                    OnPropertyChanged("Y2");
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
        public class CalloutGroup : INotifyPropertyChanged
        {
            ObservableCollection<CalloutItem> group = new ObservableCollection<CalloutItem>();
            public CalloutGroup(int nItems)
            {
                NumItems = nItems;
    
            }
            public ObservableCollection<CalloutItem> Group
            {
                get { return group; }
                set
                {
                    group = value;
                    OnPropertyChanged("Group");
                }
            }
            private double distributionHeight = 200;
    
            public double DistributionHeight
            {
                get { return distributionHeight; }
                set
                {
                    distributionHeight = value;
                    Redistribute();
                    OnPropertyChanged("DistributionHeight");
                }
            }
    
    
            private void Redistribute()
            {
                double step = distributionHeight / numItems;
                double currY = step / 2;
                var redistArr = group.ToArray();
    
                for (int i = 0; i < group.Count(); i++)
                {
                    redistArr[i].Y1 = currY;
                    currY += step;
                }
                OnPropertyChanged("Group");
            }
            private int numItems = 10;
    
            public int NumItems
            {
                get { return numItems; }
                set
                {
                    numItems = value;
                    group.Clear();
                    for (int i = 0; i < numItems; i++)
                    {
                        //group.Add(new CalloutItem());
                    }
                    Redistribute();
                    OnPropertyChanged("NumItems");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    
        public class MainWindowViewModel : INotifyPropertyChanged
        {
    
            ObservableCollection<CalloutGroup> groups = new ObservableCollection<CalloutGroup>();
    
            public ObservableCollection<CalloutGroup> Groups
            {
                get { return groups; }
                set
                {
                    groups = value;
                    OnPropertyChanged("Groups");
                }
            }
            public MainWindowViewModel()
            {
    
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected void OnPropertyChanged(string name)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }
    }
