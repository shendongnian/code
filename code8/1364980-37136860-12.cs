    public partial class MyEntity : IDataErrorInfo
    {
        public MyEntity()
        {
        }
        ...
		#region IDataErrorInfo Members
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string propertyName]
        {
            get
            {
                //Custom Validation logic
                return  MyValidator.ValidateProperty(this, propertyName);
            }
        }
        #endregion  
    }
