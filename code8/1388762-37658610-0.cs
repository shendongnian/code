    public class SessionView : BaseViewModel
    {
        private SessionView _sessionView;
        public int SessionId { get; set; }
    
		public SessionView() 
		{
            _sessionView = new SessionView();
		    _sessionView.data = from s in db.Sessions
                        where s.SessionId == SessionId
                        select new SessionView
                        {
                            CourseId = s.CourseId
                            // ... lots of other properties
                        }).FirstOrDefault();
		}
        private SessionView data
        {
            get
            {
                return _sessionView.data
            }
            set { }
        }
    
        public int CourseId { get { return data.CourseId; } set { } }
        // ... lots of other properties
    }
