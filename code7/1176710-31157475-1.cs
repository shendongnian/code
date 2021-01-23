    public abstract class BaseClass {
        private static _prop;
        static event PropertyChangedEventHandler PropertyChanged;
        private static void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(null, new PropertyChangedEventArgs(propertyName));
            }
        }
        
        public static PropType Prop {
            get { return _prop; }
            set {
                _prop = value;
                NotifyPropertyChanged("Prop");
            }
        }
        public BaseClass() {}
        protected abstract void BaseVM_PropertyChanged(object sender, PropertyChangedEventArgs e);
    }
    public class A : BaseClass {
        public A() {
            base.PropertyChanged += BaseVM_PropertyChanged;
        }
        protected override void BaseVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // react on property changes here
        }
        private void someMethod() {
            Prop = new PropType();
        }
    }
