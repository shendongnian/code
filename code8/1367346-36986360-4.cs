    [DataContract]
    public class StageContract
    {
        private int _stageID;
        private int _projectID;
        private int _wip;
        private string _name;
        private int _position;
        public StageContract(Stage s)
        {
            StageID = s.ID;
            ProjectID = s.ProjectID;
            WIP = s.WIP;
            Name = s.Name;
            Position = s.Position;
        }
        [DataMember]
        int StageID
        {
            get { return _stageID; }
            set { _stageID = value; }
        }
        [DataMember]
        int ProjectID
        {
            get { return _projectID; }
            set { _projectID = value; }
        }
        [DataMember]
        int WIP
        {
            get { return _wip; }
            set { _wip = value; }
        }
        [DataMember]
        string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        int Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
