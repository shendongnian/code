    public class Float4Proxy : INotifyPropertyChanged
    {
        private Float4 float4;
        public float X
        {
            get { return float4.x; }
            set
            {
                if (value != float4.x)
                {
                    float4.x = value;
                    PropertyChanged(this, new PropertyChangedEventArgs("X"));
                }
            }
        }
        ...
    }
