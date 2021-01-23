    public partial class Form1 : Form
    {
        public void PaintGui()//functioun which change the data in gui
        {
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            //object of some class
            //function from this object which should call PaintGui() while it working
        }
    }
---
    public class OtherClass
    {
        private Form1 _form1;
        public OtherClass(Form1 form1)
        {
            _form1 = form1;
        }
        public void CallPaintGui()
        {
            _form1.PaintGui();
        }
    }
