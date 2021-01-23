    public class MyForm : Form {  
        public int ButtonWidth(int number) //this is OK
        {
            string a = "";
            int ButtonWidth=0;
    
            Button x = new Button();
            x.Size = new Size(10, 40);//Initial Size
            x.AutoSize = true;
            x.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            Controls.Add(x);//Why i can't this one?
    
            for(int i=1;i<=number;i++)
            {
                a += "X";
                x.Text = a;
                ButtonWidth = x.Width;
    
                MessageBox.Show(i + "-" + a + "-" + ButtonWidth);
            }
            return ButtonWidth;
        }
    }
