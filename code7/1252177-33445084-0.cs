    public partial class StudentDetails : Form
    {
        private int _studentId;
        private DbContext _context;
        public StudentDetails(int studentId)
        {
            _context = new DbContext();
            _studentId = studentId;
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            Student s = _context.Students.Find(_studentId);
            displayUserName.Text = s.getUserName();
            // Using a function here is overkill, perhaps.
            // This should also work here:
            // displayUserName.Text = s.FullName;
            base.OnLoad(e);
        }
    } 
