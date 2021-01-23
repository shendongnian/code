	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		protected override CreateParams CreateParams
		{
			get
			{
				const int CS_NOCLOSE = 0x200;
				CreateParams cp = base.CreateParams;
				cp.ClassStyle |= CS_NOCLOSE;
				return cp;
			}
		}
	}
