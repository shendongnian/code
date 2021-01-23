    public partial class YourForm : Form
    {
        private string _imagePath1;
        private string _imagePath2;
       private void pictureBox1_Click(object sender, EventArgs e)
       {
            OpenFileDialog ofd1 = new OpenFileDialog();
            // ... your code
            if (ofd1.ShowDialog() == DialogResult.OK)
            {
                 pictureBox1.Image = new Bitmap(ofd1.FileName);
                 // SAVE PATH TO CLASS MEMBER
                 _imagePath1 = ofd1.FileName;
            }
       }
       private void button1_Click(object sender, EventArgs e)
       {
            // USE CLASS MEMBERS
            Compare(_imagePath1, _imagePath2);
       }
    }       
