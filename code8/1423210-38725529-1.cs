    [ProtoContract(ImplicitFields = ImplicitFields.AllPublic)]
    public class Vehicle : ObjectBaseClass
    {
        private string _BodyStyleText;
        private string _BodyStyleDescription;
        public string BodyStyleDescription
        {
            get { return _BodyStyleDescription; }
            set { _BodyStyleDescription = value; }
        }
        public string BodyStyleText
        {
            get { return _BodyStyleText; }
            set { _BodyStyleText = value; }
        }
    }
