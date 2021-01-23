    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace imagesPictureBox
    {
        public partial class Form1 : Form
        {
            int _currentIndex = 0;
            int currentIndex {
                get {
                    return _currentIndex;
                }
                set {
                    if (value >= imageList1.Images.Count) {
                        _currentIndex = 0;
                    }
                    else if (value < 0) {
                        _currentIndex = imageList1.Images.Count - 1;
                    } else {
                        _currentIndex = value;
                    }
                    pictureBox1.Image = imageList1.Images[_currentIndex];
                }
            }
            public Form1()
            {
                InitializeComponent();
                pictureBox1.Image = imageList1.Images[currentIndex];
            }
    
            private void nextBTN_Click(object sender, EventArgs e)
            {
                currentIndex++;
            }
    
            private void prevBTN_Click(object sender, EventArgs e)
            {
                currentIndex--;
            }
        }
    }
