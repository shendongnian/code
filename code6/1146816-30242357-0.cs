    void Main() {
        var f = new Foo();
        f.PropertyChanged += (sender, e) => 
            Console.WriteLine ("Changed: {0}", e.PropertyName);
    
        f.Name = "asdf";
        f.Size = 123;
    }
    
    class Foo
        : System.ComponentModel.INotifyPropertyChanged
    {
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
        private string _Name;
        public string Name {
            get {
                return this._Name;
            }
            set {
                if (this.PropertyChanged != null) {
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Name"));
                }
                this._Name = value;
            }
        }
    
        private int _Size;
        public int Size {
            get {
                return this._Size;
            }
            set {
                if (this.PropertyChanged != null) {
                    this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Size"));
                }
                this._Size = value;
            }
        }
    }
