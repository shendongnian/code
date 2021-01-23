    public partial class Form1 : Form
    {
       double tb1, tb2;
       private void button1_Click(object sender, EventArgs e)
       {
            Reading objR = new Reading();
            tb1 = double.Parse(textBox1.Text);
            tb2 = double.Parse(textBox2.Text);
           textBox4.Text= objR.mAdd(tb1,tb2).ToString();
           textBox5.Text = objR.mAdd2().ToString();
    }
    public class Reading
    {
        public double Reading(double a,double b)
        { return a+b;}
        public double mAdd(double a, double b)
        {
            return a + b;
        }      
        public double mAdd2()
        {
            return _tb1 + _tb2;
        }
    }
