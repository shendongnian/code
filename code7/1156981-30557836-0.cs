     namespace public_collection2
        {
            public partial class Form1 : Form
        
            {
                string[,] info = new string[2, 2];
                public Form1()
                {
                    InitializeComponent();
                }
        
        
                private void button1_Click(object sender, EventArgs e)
                {
                    
                    info[0, 0] = "JN";
                    info[0, 1] = "565";
                    info[1, 0] = "GD";
                    info[1, 1] = "700";
        
                    foreach (var item in info)
                    {
                        if (IsNotDigits(item))
                        {
                            comboBox1.Items.Add(item);
                        }               
                    }
        
                }
        
                bool IsNotDigits(string str)
                {
                    foreach (char c in str)
                    {
                        if (c < '0' || c > '9')
                            return true;
                    }
        
                    return false;
        
                }
        
                private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    foreach (var item in info)//info is not accessible
                    {
                        //pullout relevant number in 2d array
                    }
                }
        
            }
        } 
