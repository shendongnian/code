    namespace WindowsFormsApplication19
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                double max = 24000000, min = 23999999.85;
                double[] q = new double[10]; // Fix q: length of 10
                for (int i = 0; t < q.Length; i++) // Fix loop: start at 0
                {
                    int t = i + 1; // Fix loop: t and i need to have different values
                    q[i] = (24 * Math.Pow(10, 6)) * Math.Exp(-t / (2000 * Math.Pow(10, 6)));
                    chart1.Series[0].Points.AddXY(t, q[i]);
                }
    
                chart1.ChartAreas[0].AxisY.Maximum = max;
                chart1.ChartAreas[0].AxisY.Minimum = min;
                chart1.Series[0].ChartType = SeriesChartType.FastLine;
                chart1.Series[0].Color = Color.Red;
            }
        }
    }
