    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Windows.Forms;
    namespace tester_import
    {
    public partial class Form1 : Form
    {
        
        public Form1()
       
        {
            
            InitializeComponent();
            
        }
        private void qsearch_Click(object sender, EventArgs e)
        {
        }
        private void qsearchbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.ShowDialog();
            qsearchtxt.Text = of.FileName;
        }
        private void viewtxt_Click(object sender, EventArgs e)
        {
            string str1;
            string str2;
            string str3;
            string str4;
            string str5;
            string str6;
            string str7;
            string str8;
            string str9;
            string str10;
            string str11;
            string str12;
            string str13;
            string str14;
            string str15;
            string str16;
            string str17;
            string str18;
            string str19;
            string str20;
            string str21;
            string dir = System.IO.Path.GetDirectoryName(
      System.Reflection.Assembly.GetExecutingAssembly().Location);
     
            StreamReader sr = new StreamReader(dir+"/" + minput.Text + ".txt");
            str1 = sr.ReadLine();
            str2 = sr.ReadLine();
            str3 = sr.ReadLine();
            str4 = sr.ReadLine();
            str5 = sr.ReadLine();
            str6 = sr.ReadLine();
            str7 = sr.ReadLine();
            str8 = sr.ReadLine();
            str9 = sr.ReadLine();
            str10 = sr.ReadLine();
            str11 = sr.ReadLine();
            str12 = sr.ReadLine();
            str13 = sr.ReadLine();
            str14 = sr.ReadLine();
            str15 = sr.ReadLine();
            str16 = sr.ReadLine();
            str17 = sr.ReadLine();
            str18 = sr.ReadLine();
            str19 = sr.ReadLine();
            str20 = sr.ReadLine();
            str21 = sr.ReadLine();
            question.Text = str1.Split('"')[1];
            answerone.Text = str2.Split('"')[1];
            answertwo.Text = str4.Split('"')[1];
            answerthree.Text = str6.Split('"')[1];
            answerfour.Text = str8.Split('"')[1];
            answerfive.Text = str10.Split('"')[1];
            answersix.Text = str12.Split('"')[1];
            answerseven.Text = str14.Split('"')[1];
            answereight.Text = str16.Split('"')[1];
            answernine.Text = str18.Split('"')[1];
            answer10.Text = str20.Split('"')[1];
            sr.Close();
            
            }
        }
    }
