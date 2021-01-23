    using System;
    namespace WpfApplication1
    {
        public class VNode
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Kids { get; set; }
            //  A more beautiful way to do this would be to write an IVNodeParent
            //  interface with a single method that its children would call 
            //  when their IsSelected property changed -- thus parents would 
            //  implement that, and they could name their "selected children" 
            //  collection properties anything they like. 
            public ObservableObject Parent { get; set; }
            private bool _isSelected = false;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    if (value != _isSelected)
                    {
                        _isSelected = value;
                        if (null == Parent)
                        {
                            throw new NullReferenceException("VNode.Parent must not be null");
                        }
                        Parent.NotifyPropertyChanged("SelectedVNodes");
                    }
                }
            }
        }
    }
