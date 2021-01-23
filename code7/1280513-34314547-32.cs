    using System;
    namespace WpfApplication1
    {
        public class VNode : ObservableObject
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int Kids { get; set; }
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
                        NotifyPropertyChanged("IsSelected");
                    }
                }
            }
        }
    }
