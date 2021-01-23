     [STAThread]
     static void Main(string[] args)
     {
         string filename = "wpfimg.png";
    
         RenderAndSave(new UserControl1(), filename, 300, 300);
    
         PictureBox pb = new PictureBox();
         pb.Width = 350;
         pb.Height = 350;
         pb.Image = System.Drawing.Image.FromFile(filename);
    
         Form f = new Form();
         f.Width = 375;
         f.Height = 375;
         f.Controls.Add(pb);
         f.ShowDialog();
     }
