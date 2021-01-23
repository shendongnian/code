    class XYZ
    {
        private CustomObject theObjectINeedAReferenceTo;
        public static ObservableCollection<CustomObject> List =
            new ObservableCollection<CustomObject>();
        public void OnOpen()
        {
            theObjectINeedAReferenceTo = new CustomObject();
            List.Add(theObjectINeedAReferenceTo);
            ...
        }
        public void OnMessage()
        {
            ...
        }
    }
