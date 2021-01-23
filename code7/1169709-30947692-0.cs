    [DataContract]
    public class MyInner
    {
        public static string ConvertToString(MyInner myInner)
        {
            if (myInner == null)
                return null;
            return myInner.ToString();
        }
        public static MyInner ConvertFromString(string value)
        {
            if (value == null)
                return null;
            var firstIndex = value.IndexOf(';');
            if (firstIndex < 0)
                return new MyInner { propertyOne = value, propertyTwo = string.Empty };
            else
                return new MyInner { propertyOne = value.Substring(0, firstIndex), propertyTwo = value.Substring(firstIndex + 1, value.Length - firstIndex - 1) };
        }
        [DataMember]
        public string propertyOne { get; set; }
        [DataMember]
        public string propertyTwo { get; set; }
        public override string ToString()
        {
            return string.Format("{0};{1}", propertyOne, propertyTwo);
        }
    }
    [DataContract]
    public class MyOuter
    {
        [DataMember]
        public string propertyOne { get; set; }
        [IgnoreDataMember]
        public MyInner propertyTwo { get; set; }
        [DataMember(Name="propertyTwo")]
        string propertyTwoText
        {
            get
            {
                return MyInner.ConvertToString(propertyTwo);
            }
            set
            {
                propertyTwo = MyInner.ConvertFromString(value);
            }
        }
    }
