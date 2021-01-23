    public partial class Form1 : Form
    {
        public void PaintGui(int percent)
        {
            Label1.Text = percent.ToString() + "% completed";
            Label1.Update();
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            //object of some class
            OtherClass other = new OtherClass();
            other.DoWork(PaintGui);
        }
    }
---
    public class OtherClass
    {
        public void DoWork(Action<int> action)
        {
            for(int i=0;i<10;i++)
            {
                action(i);
                Thread.Sleep(100);
            }
        }
    }
