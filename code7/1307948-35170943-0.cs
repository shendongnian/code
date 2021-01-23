    public class User : ParseUser
    {
        public User()
        {
        }
		[ParseFieldName("myField")]
		public bool MyField { get { return GetProperty<bool>(); } set { SetProperty<bool>(value); } }
    }
