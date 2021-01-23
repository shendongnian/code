    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            private AnimatedGif _animatedGif;
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                _animatedGif = new AnimatedGif(@"..\..\playing-cards.gif");
            }
    
            private async void button1_Click(object sender, EventArgs e)
            {
                await Task.Run(() =>
                {
                    var animatedGif = _animatedGif;
                    var frames = animatedGif.Frames;
                    for (var i = 0; i < frames; i++)
                    {
                        var image = animatedGif.GetFrame(i);
                        pictureBox1.Image = image;
                        var millisecondsTimeout = animatedGif.Durations[i] * 10;
                        Thread.Sleep(millisecondsTimeout);
                    }
                });
            }
        }
    
        internal class AnimatedGif
        {
            public AnimatedGif(string filename)
            {
                if (filename == null) throw new ArgumentNullException("filename");
    
                var image = Image.FromFile(filename);
    
                var item = image.PropertyItems.SingleOrDefault(s => s.Id == 0x5100);
                if (item == null) throw new ArgumentNullException("filename");
    
                var frames = item.Value.Length / 4;
                var durations = new int[frames];
                for (var i = 0; i < frames; i++)
                {
                    durations[i] = BitConverter.ToInt32(item.Value, i * 4);
                }
    
                Frames = frames;
                Durations = durations;
                Image = image;
            }
    
            public Image Image { get; set; }
            public int Frames { get; set; }
            public int[] Durations { get; set; }
    
            public Image GetFrame(int index)
            {
                var activeFrame = Image.SelectActiveFrame(FrameDimension.Time, index);
                if (activeFrame != 0) return null;
                var bitmap = new Bitmap(Image);
                return bitmap;
            }
        }
    }
