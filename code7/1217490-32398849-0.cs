    // Composite Design Pattern
    // Leaf
    public class BaseTreeViewItem<TSource> : ViewModelBase
    {
        public BaseTreeViewItem(string name, TSource myObj)
        {
            ChildName = name;
            DataSource = myObj;
        }
        public string ChildName { get; set; }
        public TSource DataSource { get; set; }
        public override string ToString()
        {
            return ChildName;
        }
    }
    // Node
    public class MyTreeViewItem<TChild, TSource> : BaseTreeViewItem<TSource>
    {
        public ObservableCollection<TChild> Children { get; set; }
        public MyTreeViewItem(string name, TSource myObj)
            :base(name,myObj)
        {
            Children = new ObservableCollection<TChild>();
        }
        protected virtual void InitChild()
        {
            
        }
    }
    public class Level0ViewModel : MyTreeViewItem<Level1ViewModel, XmlDocument>
    {
        protected override sealed void InitChild()
        {
            base.InitChild();
            Children.Add(new Level1ViewModel("Child1", new Level1Src()));
            Children.Add(new Level1ViewModel("Child2", new Level1Src()));
        }
        public Level0ViewModel(string name, XmlDocument myObj) :
            base(name, myObj)
        {
            InitChild();
        }
    }
    public class Level1ViewModel : MyTreeViewItem<Level2TypeViewModel, Level1Src>
    {
        public Level1ViewModel(string name, Level1Src myObj)
            : base(name, myObj)
        {
            InitChild();
        }
        protected override sealed void InitChild()
        {
            base.InitChild();
            foreach (FirstType myFirstType in DataSource.FirstTypes)
            {
                Children.Add(new Level2TypeViewModel(myFirstType));
            }
            foreach (SecondType mySecondType in DataSource.SecondTypes)
            {
                Children.Add(new Level2TypeViewModel(mySecondType));
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
    // Level Type can inherit from BaseTreeViewItem<TSource>
    public class LevelType
    {
        public string Name;
    }
    // Level Type can inherit from BaseTreeViewItem<TSource>
    public class FirstType : LevelType
    {
    }
    // Level Type can inherit from BaseTreeViewItem<TSource>
    public class SecondType : LevelType
    {
    }
    public class Level2TypeViewModel : BaseTreeViewItem<LevelType>
    {
        public Level2TypeViewModel(LevelType sType)
            : base(sType.Name, sType)
        {
        }
    }
