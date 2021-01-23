    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace WpfApplication1
    {
        public class MainViewModel : ObservableObject
        {
            private ObservableCollection<VNode> _vnodes;
            public ObservableCollection<VNode> VNodes
            {
                get { return _vnodes; }
                set
                {
                    _vnodes = value;
                    NotifyPropertyChanged("VNodes");
                    NotifyPropertyChanged("SelectedVNodes");
                }
            }
            public IEnumerable<VNode> SelectedVNodes
            {
                get { return _vnodes.Where(vn => vn.IsSelected); }
            }
            Random r = new Random();
            public MainViewModel()
            {
                //hard coded data for testing
                VNodes = new ObservableCollection<VNode>();
                List<string> names = new List<string>() { "Tammy", "Doug", "Jeff", "Greg", "Kris", "Mike", "Joey", "Leslie", "Emily","Tom" };
                List<int> ages = new List<int>() { 32, 24, 42, 57, 17, 73, 12, 8, 29, 31 };
                for (int i = 0; i < 10; i++)
                {
                    VNode item = new VNode();
                    int x = r.Next(0,9);
                    item.Name = names[x];
                    item.Age = ages[x];
                    item.Kids = r.Next(1, 5);
                    item.Parent = this;
                    VNodes.Add(item);
                }
            }
        }
    }
