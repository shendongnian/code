    public partial class TestForm : Form
	{
		List<User> _userList = new List<User>();
		public TestForm()
		{
			InitializeComponent();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			User user = new User(tbName.Text, int.Parse(tbAge.Text), tbAddress.Text, tbPhone.Text);
			_userList.Add(user);
		}
	}
