     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     using System.Windows.Forms;
    
     namespace flexland
     {
         public partial class Form1 : Form
         {
             public Form1()
             {
                 InitializeComponent();
             }
             Bitmap newpic; //Put newpic here!
             public void Form1_Load(object sender, EventArgs e)
             {
                 Bitmap bmp = new Bitmap(Properties.Resources.pic1in);
                 newpic = new Bitmap(bmp); //don't declare newpic here!
                 .... //all other initializations
             }
    
             private void button1_Click(object sender, EventArgs e)
             {
                 pictureBox1.Image = newpic; //It should fix the problem
             }       
         }
     }
