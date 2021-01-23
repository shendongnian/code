    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Emgu.CV;                  //
    using Emgu.CV.CvEnum;           // usual Emgu Cv imports
    using Emgu.CV.Structure;        //
    using Emgu.CV.UI;
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using System.Runtime.InteropServices;
    using Emgu.Util;
    using System.Net;
    
    
    namespace WindowsFormsApplication1
    {
        public partial class Main : Form
        {
            public Main()
            {
                InitializeComponent();
                Run();
            }
    
            public Capture _capture;
            public Mat imgOriginal;
    
            private void imageBox2_Click(object sender, EventArgs e)
            {
            }
    
            private void label1_Click(object sender, EventArgs e)
            {
            }
            void Run()
            {
                try
                {
                    _capture = new Capture("http://192.168.1.148:8080/video");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return;
                }
    
                Application.Idle += ProcessFrame;
            }
            void ProcessFrame(object sender, EventArgs e)
            {
                Mat frame = _capture.QueryFrame();
                
                ibOriginal.Image = frame;
            }
            public void button1_Click(object sender, EventArgs e)
            {
               
               
                
            }
    
            
        }
    }
