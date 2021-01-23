	public partial class Form1 : Form
	{
	    private Timer _timer;
	    private string _connectionString; // set this to your connection string
		public Form1()
		{
            InitializeComponent();
		    _timer = new Timer()
		    {
		        Enabled = true,
		        Interval = 2000 // interval in milliseconds
		    };
		    _timer.Tick += _timer_Tick;
		}
	    private void _timer_Tick(object sender, EventArgs e)
	    {
	        using(SqlConnection cn = new SqlConnection(_connectionString))
	        {
	            cn.Open();
	            using(
	                SqlCommand cmd =
	                    new SqlCommand("select Count(*) from Issue where Return_Date < @Date", cn))
	            {
	                cmd.Parameters.AddWithValue("@Date", DateTime.Now);
	                int NumberOfOverdue = (int)cmd.ExecuteScalar();
	                if (NumberOfOverdue > 0)
	                {
	                    notifyIcon1.ShowBalloonTip(500, "Library Management System",
	                                               "There are " + NumberOfOverdue + " overdued book",
	                                               ToolTipIcon.Warning);
	                }
	            }
	        }
	    }
    }
