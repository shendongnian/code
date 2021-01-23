    [DataContract]
    [Serializable]
    public class CustomException : Exception
    {
        
        IDictionary _iDictionary;
        [DataMember]
        public override IDictionary Data
        {
            get
            {
                if (_iDictionary == null)
                {
                    _iDictionary = base.Data;
                }
                return _iDictionary;
            }
        }
    }
