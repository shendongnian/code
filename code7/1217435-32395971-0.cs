    public partial class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
        private static readonly Random _random = new Random();
        public Form1()
        {
            InitializeComponent();
            LoadDataGridView();
        }
        private void LoadDataGridView()
        {
            var list = new List<Users>()
            { 
              new Users { FirstName = "A1", LastName= "A2", MiddleName = "A3" },      
              new Users { FirstName = "B1", LastName= "A2", MiddleName = "B3" },
              new Users { FirstName = "C1", LastName= "C2", MiddleName = "C3" },
              new Users { FirstName = "A1", LastName= "A2", MiddleName = "A3" },
              new Users { FirstName = "D1", LastName= "C2", MiddleName = "A3" },
              new Users { FirstName = "A1", LastName= "A2", MiddleName = "B3" },
              new Users { FirstName = "B1", LastName= "B2", MiddleName = "A3" },
            };
            foreach (var user in list)
            {
                var localCopy = user;
                var assignedColor = list.Where(x => x.FirstName == localCopy.FirstName && x.LastName == localCopy.LastName && x.MiddleName == localCopy.MiddleName && x.BackColor != null).Select(x => x.BackColor).FirstOrDefault();
                user.BackColor = assignedColor ?? Color.FromKnownColor(GetRandomConsoleColor());
                var index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = user.FirstName;
                dataGridView1.Rows[index].Cells[1].Value = user.LastName;
                dataGridView1.Rows[index].Cells[2].Value = user.MiddleName;
                dataGridView1.Rows[index].DefaultCellStyle.BackColor = user.BackColor ?? Color.White;
            }
        }
        private static KnownColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(KnownColor));
            return (KnownColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }
    }
    public class Users
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public Color? BackColor { get; set; }
    }
