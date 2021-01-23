    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class Business
        {
        }
    
        public interface IBusinessHandler
        {
            Business Business { get; set; }
            void Execute();
        }
    
        public partial class Form1 : Form, IBusinessHandler
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            #region IBusinessHandler Members
    
            public Business Business { get; set; }
    
            public void Execute()
            {
                // check that we can continue
                if (Business == null)
                {
                    MessageBox.Show("Business property not set");
                    // or whatever else appropriate
                    return;
                }
    
                // do some work on it
                var s = Business.ToString();
                MessageBox.Show("Work done !");
            }
    
            #endregion
        }
    
        internal class Demo
        {
            public Demo()
            {
                IBusinessHandler handler = new Form1();
                handler.Business = new Business();
                handler.Execute();
            }
        }
    }
