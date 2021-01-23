    public partial class Form1 : Form
    {
        private static double Total { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            var ctrl = groupBox1;
            foreach (var checkBox in ctrl.Controls.OfType<CheckBox>())
            {
                Total = checkBox.Checked ? (Total + Convert.ToDouble(checkBox.Tag)) : Total;
            }
        }
    }
