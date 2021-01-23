    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.Resources;
    using System.Collections;
    namespace PicBoxIteration
    {
        public partial class Form1 : Form
        {
            ResourceSet resourceSet;
            IDictionaryEnumerator iDict;
            Dictionary<int, Bitmap> imgDict = new Dictionary<int, Bitmap>();
            int currentIndex = 0;
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                resourceSet =     Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentCulture, true, true);
                iDict = resourceSet.GetEnumerator();
                foreach (DictionaryEntry entry in resourceSet)
                {
                    imgDict.Add(currentIndex, (Bitmap) entry.Value);  
                    currentIndex ++;
                }
                currentIndex = 0;
                pictureBox1.Image = imgDict[currentIndex];
               
            }
    
            private void btnNext_Click(object sender, EventArgs e)
            {
                if (currentIndex < imgDict.Count - 1)
                {
                    currentIndex++;
    
    
                }
                else
                {
                    currentIndex = 0;
                }
                pictureBox1.Image = imgDict[currentIndex];
            }
    
            private void btnBack_Click(object sender, EventArgs e)
            {
                if (currentIndex > 0)
                {
                    currentIndex--;
                }
                else
                {
                    currentIndex = imgDict.Count -1;
                }
                pictureBox1.Image = imgDict[currentIndex];
            
            }
        }
    }
