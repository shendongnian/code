    public partial class Form1 : Form
    {   
        MJPEGStream stream;
        AVIWriter writer;
        bool toggleRec = false;
        public Form1()
        {
            InitializeComponent() ;
           
        }
        void stream_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            
            Bitmap bmp = (Bitmap)eventArgs.Frame.Clone();
            bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            pictureBox1.Image = bmp;
            try
            {
                if (toggleRec == true)
                {
                    bmp = (Bitmap)eventArgs.Frame.Clone();
                    bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    writer.AddFrame(bmp);
                }
            }
            catch (Exception e)
            {
                
               
            }
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                stream = new MJPEGStream(textBox1.Text);
                stream.NewFrame +=stream_NewFrame;
                stream.Start();
            }
            catch
            {
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (stream.IsRunning == true)
                {
                    stream.Stop();
                }
            }
            catch
            { 
            }
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            
            try
            {
                pictureBox1.Image = (Bitmap)pictureBox1.Image.Clone();
                pictureBox1.Image.Save("D:\\Pictures\\pix-" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss" + ".jpeg" + ImageFormat.Jpeg));
            }
            catch (Exception)
            {
                MessageBox.Show("Capture Image First");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
       
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        
        private void button5_Click(object sender, EventArgs e)
        {
            if (toggleRec == false)
            {
                SaveFileDialog saveAVI = new SaveFileDialog();
                saveAVI.Filter = "AVI Files (*.avi)|*.avi";
                if (saveAVI.ShowDialog() == DialogResult.OK)
                {
                     writer = new AVIWriter("XVID");
                     writer.Open(saveAVI.FileName , 480, 640);
                     toggleRec = true;
                     Label lblRec =new Label();
                }
            }
           
        }
        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                writer.Close();
                MessageBox.Show("video recorded successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
