    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        int numVars = 2;
    
        // You'll eventually need to obtain the values in the boxes
        TextBox[][] tb;
    
        private void button1_Click(object sender, EventArgs e)
        {
            // Remove existing controls
            this.panel1.Controls.Clear();
    
            // Obtain number of variables
            numVars = (int)numericUpDown1.Value;
    
            // Create the TextBoxes
            tb = new TextBox[numVars][];
    
            // Initialize each jagged array
            for(int i = 0; i < numVars; i++)
                tb[i] = new TextBox[numVars + 1];
    
            // Create the Textboxes
            int height = 20;
            int width = 50;
            int curX = 10;
            int curY = 10;
            for(int i = 0; i < numVars; i++)
            {
                for(int j = 0; j < numVars + 1; j++)
                {
                    TextBox txtbox = new TextBox();
                    txtbox = new TextBox();
                    txtbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    txtbox.Left = curX;
                    txtbox.Top = curY;
                    txtbox.Width = width;
                    txtbox.Height = height;
                    txtbox.Font = new Font(txtbox.Font.FontFamily, 16);
                    txtbox.BackColor = Color.Cyan;
                    txtbox.TextAlign = HorizontalAlignment.Center;
    
                    tb[i][j] = txtbox;
                    this.panel1.Controls.Add(tb[i][j]); // Add as a child of panel
    
                    curX += width + 15;
                }
    
                curX = 10;
                curY = curY + height + 20;
            }
        }
    }
