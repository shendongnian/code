    public partial class MyForm : Form
    {
        Model _Model = new Model();
        public MyForm()
        {
            InitializeComponent();
            MyChart.Series.First().XValueMember = "X";
            MyChart.Series.First().YValueMembers = "Y";
            MyChart.DataSource = _Model.DoubleList;
        }
        private void button1_Click( object sender, EventArgs e )
        {
            _Model.UpdateModel( 4.0, 5.0, 6.0, 7.0 );
            MyChart.DataBind();
        }
    }
