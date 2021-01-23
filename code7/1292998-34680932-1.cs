	public partial class Form1 : Form
	{
		private readonly List<Poco> _pocos = new List<Poco>();
		public IEnumerable<Poco> Pocos { get { return _pocos; }} 
		public Form1()
		{
			_pocos.AddRange(new[] {
                new Poco {Name = "Poco1", Description = "Description1"},
                new Poco {Name = "Poco2", Description = "Description2"}
            });
			InitializeComponent();
			listBox1.DataSource = Pocos;
			listBox1.DisplayMember = "Name";
		}
