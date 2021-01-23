    public class ParentViewModel
    {
        public IEnumerable<ChildViewModel> Children { get; set; }
        // other properties
        public static ParentViewModel BuildViewModel(Parent parent)
        {
            return new ParentViewModel
            {
                Children = parent.Children.Select(c => ChildViewModel.BuildViewModel(c)),
                // other properties
            };
        }
    }
    public class ChildViewModel
    {
        // other properties
        public static ChildViewModel BuildViewModel(Child child)
        {
            return new ChildViewModel
            {
                // other properties
            };
        }
    }
