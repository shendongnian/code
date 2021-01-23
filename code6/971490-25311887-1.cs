    public class ElementViewModel : XTRRABase
    {
        public Element _element;
        public ElementViewModel(Element element)
        {
            _element = element;
        }
        public int Number
        {
            get { return _element.Number; }
            set { _element.Number = value; NotifyPropertyChanged(); }
        }
        public double WTF
        {
            get { return _element.WTF; }
            set { _element.WTF = value; NotifyPropertyChanged(); }
        }
        public String ElementInfo
        {
            get { return XTRRAApp.Application.AtomicElementList.GetElements()[Number]; }
            set { }
        }
    }
