    public partial class Form1 : Form
    {
    Timer timer;
    Random random;
    int xaxis;
    public Form1()
    {
        InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        random = new Random();
        timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += timer_Tick;
        timer.Start();
    }
    void timer_Tick(object sender, EventArgs e)
    {
        chart1.Series[0].Points.AddXY(xaxis++, random.Next(1, 7));
        if (chart1.Series[0].Points.Count > 10)
        {
            chart1.Series[0].Points.Remove(chart1.Series[0].Points[0]);
            chart1.ChartAreas[0].AxisX.Minimum = chart1.Series[0].Points[0].XValue;
            chart1.ChartAreas[0].AxisX.Maximum = xaxis;
        }
    }
