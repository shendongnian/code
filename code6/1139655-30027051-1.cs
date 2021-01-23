    public class Form1
    {
        private int[] AppliancePower = new[]
        {
            5000,
            4000,
            7000
        };
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                var value = AppliancePower[0];
                DoSomeFanyCalculation(value);
                this.textBox1.Text = value.ToString();
            }
            else
            {
                this.textBox1.Text = String.Empty;
            }
        }
    }
