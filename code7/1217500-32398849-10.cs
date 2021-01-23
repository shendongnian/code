    public class BaseTreeViewItem<TSource, TParent> : ViewModelBase
    {
        // add static field to hold selected Item
        public static BaseTreeViewItem<TSource, TParent> SelectedChild { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                if (SelectedChild != null)
                {
                    SelectedChild.IsSelected = false;
                    SelectedChild = null;
                }
                _isSelected = value;
                if (_isSelected)
                    SelectedChild = this;
                // NotifyPropertyChanged
            }
        }
        public TParent Parent
        {
            get;
            private set;
        }
        public BaseTreeViewItem(string name, TSource myObj, TParent parent)
        {
            ChildName = name;
            DataSource = myObj;
            Parent = parent;
        }
        public string ChildName { get; set; }
        public TSource DataSource { get; set; }
        public override string ToString()
        {
            return ChildName;
        }
    }
    // Node
    
    public class MyTreeViewItem<TChild, TSource, TParent> : BaseTreeViewItem<TSource, TParent>, IDeleteItem
        where TParent : IDeleteItem
        where TChild : class
    {
        
        public ObservableCollection<TChild> Children { get; set; }
        public MyTreeViewItem(string name, TSource myObj, TParent parent)
            :base(name,myObj, parent)
        {
            Children = new ObservableCollection<TChild>();
        }
        protected virtual void InitChild()
        {
            
        }
        public void DeleteItem(object myTreeViewItem)
        {
            Children.Remove(myTreeViewItem as TChild);
        }
        public static void DeleteSelectedItem()
        {
            if (SelectedChild != null && SelectedChild.Parent != null)
            {
                SelectedChild.Parent.DeleteItem(SelectedChild);
            }
        }
    }
    public class Level0ViewModel : MyTreeViewItem<Level1ViewModel, XmlDocument, IDeleteItem>
    {
        protected override sealed void InitChild()
        {
            base.InitChild();
            Children.Add(new Level1ViewModel("Child1", new Level1Src(), this));
            Children.Add(new Level1ViewModel("Child2", new Level1Src(), this));
        }
        public Level0ViewModel(string name, XmlDocument myObj) :
            base(name, myObj,null)
        {
            InitChild();
        }
    }
    public class Level1ViewModel : MyTreeViewItem<Level2TypeViewModel, Level1Src, Level0ViewModel>
    {
        public Level1ViewModel(string name, Level1Src myObj, Level0ViewModel parent)
            : base(name, myObj, parent)
        {
            InitChild();
        }
        protected override sealed void InitChild()
        {
            base.InitChild();
            foreach (FirstType myFirstType in DataSource.FirstTypes)
            {
                Children.Add(new Level2TypeViewModel(myFirstType, this));
            }
            foreach (SecondType mySecondType in DataSource.SecondTypes)
            {
                Children.Add(new Level2TypeViewModel(mySecondType, this));
            }
        }
        // Use linq if tou want child by type
        public IEnumerable<Level2TypeViewModel> ChildType1 
        {
            get
            {
                return Children.Where(item => item.DataSource is FirstType);
            }
        }
        public IEnumerable<Level2TypeViewModel> ChildType2
        {
            get
            {
                return Children.Where(item => item.DataSource is SecondType);
            }
        }
    }
    public class LevelType
    {
        public string Name;
    }
    public class FirstType : LevelType
    {
    }
    public class SecondType : LevelType
    {
    }
    public class Level2TypeViewModel : BaseTreeViewItem<LevelType, Level1ViewModel>
    {
        public Level2TypeViewModel(LevelType sType, Level1ViewModel parent)
            : base(sType.Name, sType, parent)
        {
        }
    }
