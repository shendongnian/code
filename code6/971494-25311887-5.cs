    [DisplayName("Elements")]
    public class ElementListViewModel : XTRRABase
    {
        protected List<Element> _elements;
        public ElementListViewModel(List<Element> elements)
        {
            _elements = elements;
        }
        [Browsable(false)]
        public int Count
        {
            get { return _elements.Count; }
            set 
            { 
                while(value < _elements.Count)
                {
                    _elements.RemoveAt(_elements.Count - 1);
                }
                while(value > _elements.Count)
                {
                    _elements.Add(new Element(0,0));
                }
                NotifyPropertyChanged();
                NotifyPropertyChanged("Elements");
            }
        }
        [PropertyOrder(1), DisplayName("Elements")]
        [Editor(typeof(ElementUCEditor), typeof(ElementUCEditor))]
        public ObservableCollection<ElementViewModel> Elements
        {
            get
            {
                ObservableCollection<ElementViewModel> list = new ObservableCollection<ElementViewModel>();
                foreach(Element element in _elements)
                {
                    list.Add(new ElementViewModel(element));
                }
                return list;
            }
            set { }
        }
    }
