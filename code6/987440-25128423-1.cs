    //the interface
    public interface IShouldntDoThis
    {
        void MyTextBox_Validating(object sender, CancelEventArgs e);
    }
    //the control
    public class MyTextBox : TextBox
    {
        public MyTextBox()
        {
            
        }
        protected override void InitLayout()
        {
            base.InitLayout();
            Control parent = this.Parent;
            while (parent.Parent != null)
            {
                parent = parent.Parent;
            }
            //parent should now be the Form
            IShouldntDoThis test = parent as IShouldntDoThis;
            if (test != null)
            {
                this.Validating += test.MyTextBox_Validating;
            }
        }
    }
    //the form
    public partial class MainForm : Form, IShouldntDoThis
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void MyTextBox_Validating(object sender, CancelEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
