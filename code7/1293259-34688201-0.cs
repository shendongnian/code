    namespace Locker_Rental
    {    
    public partial class Form1 : Form
        {
            public object ikr1 { get; private set; }
            public Button myButton;
    
            public Form1()
            {
                InitializeComponent();
                button4.Visible = false;
                myButton = new Button();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                hide_buttons();
                build_LL1_Key_Lockers();
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                hide_buttons();
                build_LL1_Combo_Lockers();
            }
    
            private void button3_Click(object sender, EventArgs e)
            {
                hide_buttons();
                build_L2_Combo_Lockers();
            }
    
            private void hide_buttons()
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
            }
    
            private void show_buttons()
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
            }
    
            private void build_LL1_Key_Lockers()
            {
                button4.Visible = true;
                myButton = new Button();
                myButton.Location = new Point(25, 25);
                myButton.Text = "1";
                myButton.Size = new Size(50, 50);
                myButton.BackColor = System.Drawing.SystemColors.ButtonFace;
                Controls.Add(myButton);
    
            }
    
            private void build_LL1_Combo_Lockers()
            {
                button4.Visible = true;
            }
    
            private void build_L2_Combo_Lockers()
            {
                button4.Visible = true;
            }
    
            private void button4_Click(object sender, EventArgs e)
            {
                button4.Visible = false;
                //turn off ikr1
                myButton.Visible = false;
    
                show_buttons();
            }
        }
    }
