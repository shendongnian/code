    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        class Settings
        {
     
    
            public static string FutureDate { get; set; }
    
        }
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
                Settings.FutureDate = "8/16/2014 3:07:09 PM";
            }
    
    
    
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                DateTime currentDate = DateTime.Now;
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime futureDate = DateTime.ParseExact(Settings.FutureDate, "M/d/yyyy h:mm:ss tt", provider);
    
                if (currentDate >= futureDate) //TargetInvocationException error occurs here
                {
                    MessageBox.Show("Three days has passed.");
                }
            }
        }
    }
