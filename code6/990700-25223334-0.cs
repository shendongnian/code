    using System;
    usingSystem.Collections.Generic;
    usingSystem.ComponentModel;
    usingSystem.Data;
    usingSystem.Drawing;
    usingSystem.Linq;
    usingSystem.Text;
    usingSystem.Windows.Forms;
    using System.IO;
    
    namespaceMiPrimerJuego
    {
    publicpartialclassForm1 : Form
        {        
    public Form1()
            {
    InitializeComponent();
            }
    
    privatevoid button1_Click(object sender, EventArgs e)
    {
    int x = 20;
    int y = 600;
    List<System.Windows.Forms.PictureBox>objeto = newList<PictureBox>();
    for (inti = 0; i< 10; i++, x += 90)
                {
    PictureBoxpBox = newPictureBox();                
    pBox.Height = 80;
    pBox.Width = 50;
    pBox.Location = newSystem.Drawing.Point(x, y);
    objeto.Add(pBox);
    pBox.SizeMode = PictureBoxSizeMode.StretchImage;                
    Controls.Add(pBox);
    
    var rand = newRandom();
    var files = Directory.GetFiles(Application.StartupPath + @"/Images", "*.gif");
    pBox.Image = System.Drawing.Bitmap.FromFile(files[rand.Next(files.Length)]);
                }
            }        
        }
    }
