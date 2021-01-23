    namespace winMultiCastDelegate
    {
        public partial class Form1 : Form
        {
            public delegate void ChangeBackColorDelegate(Color backgroundColor);
    
            //just avoid null check  instanciate it with fake delegate.
            public event ChangeBackColorDelegate ChangeBackColor = delegate { };
            public Form1()
            {
                InitializeComponent();
    
               
                //instanciate child form for N time.. just to simulate
                for (int i = 0; i < 3; i++) 
                {
                    var childForm = new ChildForm();
                    //subscribe parent event
                    this.ChangeBackColor += childForm.ChangeColor;
                    //show every form
                    childForm.Show();
                }
    
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ChangeBackColor.Invoke(Color.Black);
            }
        }
        /// <summary>
        /// child form class having text box inside
        /// </summary>
        public class ChildForm : Form 
        {
            private TextBox textBox;
            public ChildForm() 
            {
    
                textBox = new TextBox();
                textBox.Width = 200;
                this.Controls.Add(textBox);
            }
            public void ChangeColor(Color color) 
            {
                textBox.BackColor = color;
            }
        }
    
        
    }
