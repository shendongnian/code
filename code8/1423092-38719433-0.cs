    public class UserDetails
    {
        int? _userId;
        string _emailId;
        string _userName;
        int _timezoneMins;
        string _customLogo;
        string _isExecutive;
        int _hasNTID;
        int? _org_Id;
        string _org_Name;
        string _designation;
        int? _location;
        string _location_Name;
        string _wsVersion;
        string _callMe;
        string _gPS;
        string _feedback_IMSR;
        string _rPT_Widgets_Access;
        [JsonProperty(PropertyName = "Feedback_IM&SR")]
        public string Feedback_IMSR
        {
           get{return _feedback_IMSR;}
           set{_feedback_IMSR = value;}
        }
    }
