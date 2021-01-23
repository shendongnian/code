    public interface ISelectable
    {
        bool IsSelected { get; set; }
    }
    public abstract class MultiEditable<T> : ObservableCollection<T> where T:class,ISelectable,INotifyPropertyChanged
    {
        private T _EditItem;
        public T EditItem 
        {
            get { return _EditItem; }
            set 
            { 
                if(_EditItem != value)
                {
                    _EditItem = value;
                    _EditItem.PropertyChanged += _EditItem_PropertyChanged;
                }
            }
        }
        public bool AreMultipleItemsSelected
        {
            get { return this.Count(x => x.IsSelected) > 1; }
        }
        public virtual void _EditItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            
        }
    }
    public class MultiEditableBeams : MultiEditable<Beam> 
    {
        public override void _EditItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base._EditItem_PropertyChanged(sender, e);
            foreach (Beam beam in this.Where(x => x.IsSelected))
            {
                if (e.PropertyName == "Material")
                    beam.Material = EditItem.Material;
                else if (e.PropertyName == "Length")
                    beam.Length = EditItem.Length;
            }
        }
    }
    public class Beam : ISelectable, INotifyPropertyChanged
    {
        private bool _IsSelected;
        public bool IsSelected 
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    RaisePropertyChanged();
                }
            }
        }
        private string _Material;
        public string Material
        {
            get { return _Material; }
            set
            {
                if (_Material != value)
                {
                    Material = value;
                    RaisePropertyChanged();
                }
            }
        }
        private int _Length;
        public int Length
        {
            get { return _Length; }
            set
            {
                if (_Length != value)
                {
                    _Length = value;
                    RaisePropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
