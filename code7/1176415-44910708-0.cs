    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Converting_Image_to__Black_and_White
    {
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static int siyahbeyazsinirnoktasi=0;
        public static string DosyaYolu = "";
        #region resim üzerinde işlemler yapma (siyah beyaz)
        Bitmap BlackandWhite(Bitmap Goruntu)
        {
            Bitmap yeniGoruntu = new Bitmap(Goruntu.Width, 
         Goruntu.Height);//Bitmap sınıfımızı oluşturduk.
        
            double toplampikselsayisi = Goruntu.Width * Goruntu.Height;
            int GriTonlama;
            for (int i = 0; i < Goruntu.Width; i++)//resmi yatay olarak 
    taramak için
            {
                for (int j = 0; j < Goruntu.Height; j++)//resmi dikey olarak 
    taramak için
                {
                    Color Pixel = Goruntu.GetPixel(i, j);//color sınıfını ile 
    pixel rengini alıyoruz.
                    GriTonlama = (Pixel.R + Pixel.G + Pixel.B) / 3;//almış 
    olduğumuz renk değerini gri tona çevirmek için kullanmamız gereken 
    formül.
                    if (GriTonlama < siyahbeyazsinirnoktasi)
                    {
                        yeniGoruntu.SetPixel(i, j, Color.FromArgb(0, 0, 
    0));//yeni görüntümüze gri tonlamadaki pixel değerini veriyoruz.
                    }
                    if (GriTonlama >= siyahbeyazsinirnoktasi)
                    {
                        yeniGoruntu.SetPixel(i, j, Color.FromArgb(255, 255, 
    255));//yeni görüntümüze gri tonlamadaki pixel değerini veriyoruz.
                    }
                    
                }
            }
            
            return yeniGoruntu;
        }
        #endregion
 
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            
            FolderBrowserDialog Klasor = new FolderBrowserDialog();
            openFileDialog1.Title = "Resimdosyası seçiniz.";
            openFileDialog1.Filter = "Image files (*.jpg)|*.jpg|Tüm 
    dosyalar(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                 DosyaYolu = openFileDialog1.FileName;
                var dosyaboyutu = new FileInfo(DosyaYolu).Length;
               
                if (dosyaboyutu <= 500000)
                {
                    pictureBox1.Image = new 
    Bitmap(openFileDialog1.OpenFile());
                    btnConvertBlackandWhite.Enabled = true;
                    label1.Visible = true;
                    label2.Visible= true;
                    label3.Visible = true;
                    label4.Visible = true;
                    label5.Visible = true;
                    label6.Visible = true;
                    trackBar1.Visible = true;
                }
                else
                {
                    MessageBox.Show("Seçtiğiniz resim boyutu 500 KB'nın 
    altında olmalıdır.");
                }
            }
        }
        private void btnConvertBlackandWhite_Click(object sender, EventArgs 
     e)
        {
            pictureBox1.Image = BlackandWhite(new Bitmap(DosyaYolu));
            btnSave.Enabled = true;
            
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            siyahbeyazsinirnoktasi = trackBar1.Value ;
            label3.Text = Convert.ToString(siyahbeyazsinirnoktasi);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "130";
            siyahbeyazsinirnoktasi = 130;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            {
                Image pngoptikform = new Bitmap(pictureBox1.Image);
                SaveFileDialog sf = new SaveFileDialog();//yeni bir kaydetme 
    diyaloğu oluşturuyoruz.
                sf.Filter = "Image file (Jpg dosyası (*.jpg)|*.jpg  ";//.bmp 
    veya .jpg olarak kayıt imkanı sağlıyoruz.
                sf.Title = "Kayıt";//diğaloğumuzun başlığını belirliyoruz.
                sf.CheckPathExists = true;
                sf.DefaultExt = "jpg";
                sf.FilterIndex = 1;
               
                DialogResult sonuc = sf.ShowDialog();
                if (sonuc == DialogResult.OK)
                {
                    if (sf.FilterIndex == 1)
                    {
                        pngoptikform.Save(sf.FileName);
                        System.Diagnostics.Process.Start(sf.FileName);
                    }
                }
            }
        }
    }
    }
