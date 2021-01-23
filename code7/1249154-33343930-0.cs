    using System;
    using System.Windows.Forms;
    using System.Drawing;
    
    
    namespace WindowsFormsApplication2
    {
        public class CHauptfenster : Form
        {
            public Label labelAusgabe;
    
            public CHauptfenster()
            {
                Text = "Begruessung";
                Width = 400;
                Height = 250;
    
                labelAusgabe = new Label();
                labelAusgabe.Height = 30;
                labelAusgabe.Width = 350;
                labelAusgabe.Left = (this.Width / 2) - (labelAusgabe.Width / 2);
                labelAusgabe.Top = 50;
                labelAusgabe.Text = "Hallo Windows!";
                labelAusgabe.Font = new System.Drawing.Font("Arial", 20);
                labelAusgabe.TextAlign = ContentAlignment.MiddleCenter;
                Controls.Add(labelAusgabe);
            }
        }
    static void Main()
    {
       Application.Run(new CHauptfenster());
    }
    }
