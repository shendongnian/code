    public class GroupViewModel
    {
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class ItemViewModel
    {
        public ItemViewModel(List<GroupViewModel> groups)
        {
            Groups = new ListCollectionView(groups)
            {
                Filter = g =>
                {
                    var group = (GroupViewModel)g;
                    return !group.IsDeleted || (Group == group);
                }
            };
        }
        public string Name { get; set; }
        public GroupViewModel Group
        {
            get { return group; }
            set
            {
                if (group != value)
                {
                    group = value;
                    Groups.Refresh();
                }
            }
        }
        private GroupViewModel group;
        public ICollectionView Groups { get; private set; }
    }
    public class ListViewModel
    {
        private readonly List<GroupViewModel> groups;
        public ListViewModel()
        {
            // some sample initialization
            groups = new List<GroupViewModel>
            {
                new GroupViewModel { Name = "Friuts" },
                new GroupViewModel { Name = "Animals" },
                new GroupViewModel { Name = "Trees", IsDeleted = true }
            };
            Items = new List<ItemViewModel>
            {
                new ItemViewModel(groups) { Name = "Orange", Group = groups[0] },
                new ItemViewModel(groups) { Name = "Apple", Group = groups[0] },
                new ItemViewModel(groups) { Name = "Banana", Group = groups[0] },
                new ItemViewModel(groups) { Name = "Cat", Group = groups[1] },
                new ItemViewModel(groups) { Name = "Dog", Group = groups[1] },
                new ItemViewModel(groups) { Name = "Bird", Group = groups[1] },
                new ItemViewModel(groups) { Name = "Oak", Group = groups[2] },
                new ItemViewModel(groups) { Name = "Nut-tree", Group = groups[2] },
                new ItemViewModel(groups) { Name = "Pine", Group = groups[2] },
            };
        }
        public IEnumerable<ItemViewModel> Items { get; private set; }
    }
