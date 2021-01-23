    public class CustomException : Exception
    {
        [IgnoreDataMemberAttribute]
        IDictionary _iDictionary;
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
