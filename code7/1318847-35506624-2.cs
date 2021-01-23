    public abstract class Element: INotifyPropertyChanged
    {
        bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                _isSelected = value;
                OnPropertyChanged();
            }
        }
    }
    public class EllipseElement : Element {}
    public class RectangleElement : Element {}
