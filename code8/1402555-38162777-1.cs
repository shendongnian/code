    public partial class Form1 : Form
    {
        SizedTifImage _tif;
    
        private void btn_Open_Click(object sender, EventArgs e)
        {
           ...
            _tif = new SizedTifImage(@"Large_Tif_Image_15pages.tif", pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = _tif.GetFrame(0);
            btn_Next_Click(null, null);
        }
    
        private void btn_Next_Click(object sender, EventArgs e)
        {
            counter++;
            if (counter >= _tif.FrameCount)
            {
                counter = _tif.FrameCount - 1;
                btn_Next.Enabled = false;
            }
            btn_Next.Enabled = false;
            LoadPage();
            btn_Next.Enabled = true;
        }
    
        private void LoadPage()
        {
            StartWatch();
            pictureBox1.Image = _tif.GetFrame(counter);
            Stopwatch();
        }
    }
    
    public class SizedTifImage : IDisposable
    {
        private Image _image;
        private ConcurrentDictionary<int, Image> _frames = new ConcurrentDictionary<int, Image>();
    
        public SizedTifImage(string filename, int width, int height)
        {
            Width = width;
            Height = height;
            _image = Image.FromFile(filename);
            FrameCount = _image.GetFrameCount(FrameDimension.Page);
            ThreadPool.QueueUserWorkItem(ResizeFrame);
        }
    
        public int FrameCount { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
    
        private void ResizeFrame(object state)
        {
            for (int i = 0; i < FrameCount; i++)
            {
                if (_image == null)
                    return;
    
                _image.SelectActiveFrame(FrameDimension.Page, i);
                var bmp = new Bitmap(Width, Height);
                using (var g = Graphics.FromImage(bmp))
                {
                    if (_image == null)
                        return;
    
                    g.DrawImage(_image, 0, 0, bmp.Width, bmp.Height);
                }
                _frames.AddOrUpdate(i, bmp, (k, oldValue) => { bmp.Dispose(); return oldValue; });
            }
        }
    
        public Image GetFrame(int i)
        {
            if (i >= FrameCount)
                throw new IndexOutOfRangeException();
    
            if (_image == null)
                throw new ObjectDisposedException("Image");
    
            Image img;
            do
            {
                if (_frames.TryGetValue(i, out img))
                    return img;
    
                Thread.Sleep(10);
            }
            while (true);
        }
    
        public void Dispose()
        {
            var images = _frames.Values.ToArray();
            _frames.Clear();
            foreach (var img in images)
            {
                img.Dispose();
            }
    
            if (_image != null)
            {
                _image.Dispose();
                _image = null;
            }
        }
