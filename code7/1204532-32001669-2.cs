    public class Form1 : Form
    {
        private static Form1 _instance;
        public Form1()
        {
            InitializeComponent();
            _instance = this;
        }
        private static int updateHeatmapURL()
        {
            ...
            selectGaze.Parameters.Add("@heatmapURL", MySqlDbType.VarChar).Value = _instance.dlg.FileName;
            var userId = getUserID();
            selectGaze.Parameters.Add("@userID", MySqlDbType.Int64).Value = userId;
            selectGaze.Parameters.Add("@gazeID", MySqlDbType.Int64).Value = getgazeID(userId);
            ...
        }
    }
