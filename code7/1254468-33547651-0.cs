    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Data;
    
    namespace WpfApplication3
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private Items MyItems;
            private int NextGroupId = 0;
            public MainWindow()
            {
                InitializeComponent();
                MyItems = new Items();
                tvMain.ItemsSource = MyItems.Groups as IEnumerable;
            }
            private void btnNewGroup_Click(object sender, RoutedEventArgs e)
            {
                MyItems.Add(new ItemGroup(MyItems)
                {
                    Name = Guid.NewGuid().ToString(),
                    GroupId = NextGroupId
                });
                NextGroupId++;
            }
            private void btnNewSubItem_Click(object sender, RoutedEventArgs e)
            {
                MyItems.Add(new SubItem(MyItems)
                {
                    Name = Guid.NewGuid().ToString(),
                    GroupId = (tvMain.SelectedItem as ItemGroup).GroupId
                });
            }
    
            private void tvMain_SelectedItemChanged(object sender,
                RoutedPropertyChangedEventArgs<object> e)
            {
                btnNewSubItem.IsEnabled = tvMain.SelectedItem is ItemGroup;
            }
        }
        public class Items
        {
            public ObservableCollection<BaseItem> ItemList { get; private set; }
            public ICollectionView Groups { get; private set; }
            public Items()
            {
                ItemList = new ObservableCollection<BaseItem>();
                Groups = CollectionViewSource.GetDefaultView(ItemList);
                Groups.Filter = item => item is ItemGroup;
            }
            public void Add(BaseItem item)
            {
                ItemList.Add(item);
                if (item is SubItem)
                    ItemList
                        .OfType<ItemGroup>()
                        .Where(g => g.GroupId == item.GroupId)
                        .Single()
                        .NotifyPropertyChanged("Children");
            }
        }
        public class BaseItem : INotifyPropertyChanged
        {
            protected Items _List;
            public BaseItem(Items List)
            {
                _List = List;
            }
            public string Name { get; set; }
            public int GroupId { get; set; }
            public event PropertyChangedEventHandler PropertyChanged;
            public void NotifyPropertyChanged(string propName)
            {
                if (this.PropertyChanged != null)
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public class ItemGroup : BaseItem
        {
            public ItemGroup(Items _List)
                : base(_List) { }
            public IEnumerator Children
            {
                get
                {
                    return _List.ItemList
                        .OfType<SubItem>()
                        .Where(SI => SI.GroupId == this.GroupId)
                        .GetEnumerator();
                }
            }
        }
        public class SubItem : BaseItem
        {
            public SubItem(Items _List)
                : base(_List) { }
        }
    }
