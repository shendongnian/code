    public class A<T> : ModelBase<T> where T : A<T>
    {
        //properties, constructors, methods..
    }
    public class B : A<B>
    {
        private string additionalProperty;
        public string AdditionalProperty
        {
            get { return additionalProperty; }
            set
            { 
                additionalProperty = value; 
                NotifyPropertyChanged(m => m.AdditionalProperty);
            }
        }
    }
