    public partial class AddStudent : Form
        {
    Student stu = null;
    public AddStudent()
    {
        InitializeComponent();
        stu = new Student();
        stu.Show();
    }
