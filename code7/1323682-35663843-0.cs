    public partial class GeneratorProperty<T> where T: IComparable<T>
    {
        ...
        public T Value
        {
            get {... }
            set 
            {
                if (this.Max.CompareTo(value) == -1)
                    this._value = this.Max;
                else if (this.Min.CompareTo(value) == 1)
                    this._value = this.Min;
                else
                    this._value = value;
            }
        }
    }
