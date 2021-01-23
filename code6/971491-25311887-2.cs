        ElementListViewModel _elements;
        [PropertyOrder(4), DisplayName("Elements")]
        [ExpandableObject]
        [Editor(typeof(ElementHeaderUCEditor), typeof(ElementHeaderUCEditor))]
        public ElementListViewModel Elements
        {
            
            get { return (_elements = new ElementListViewModel(_material.Elements) ); }
            set {}
        }
