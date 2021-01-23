    interface IMenu
    {
        // if it's a menu, then it has a 'Visible' property
        bool Visible { get; }
    }
    class ParentClass
    {
        public IEnumerable<IMenu> TopLevelMenu { get; }
        public IEnumerable<IMenu> MidLevelMenu { get; }
        public IEnumerable<IMenu> BottomLevelMenu { get; }
    }
