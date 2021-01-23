    using Finisar.SQLite;
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
    
    namespace SQLiteDb
    {
        public partial class Final_Form : Form
        {
            public Final_Form()
            {
                InitializeComponent();
            }
            SQLiteConnection con = new SQLiteConnection("Data Source=database.db;Version=3;New=False;Compress=True;");
            Image image;
            private void Upload_image_Click(object sender, EventArgs e)
            {
                DialogResult = openFileDialog1.ShowDialog();
                if (DialogResult == DialogResult.OK)
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    image = pictureBox1.Image;
                }
            }
    
            private void Save_Click(object sender, EventArgs e)
            {
                byte[] imagesBytes = Image2Byte(pictureBox1.Image);
                SaveImage(imagesBytes);
            }
    
            private void Show_Click(object sender, EventArgs e)
            {
                LoadImageFromDb();
            }
            //Retrive Image Code. . 
    
            private void LoadImageFromDb()
            {
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand("Select FileImage from ForImage where ID='86';", con);
                byte[] arrayFromDb = (byte[])cmd.ExecuteScalar();
                con.Close();
                pictureBox2.Image = ByteToImage(arrayFromDb);
            }
            private Image ByteToImage(byte[] toConvert)
            {
                MemoryStream toImage = new MemoryStream(toConvert);
                Image imageFromBytes = Image.FromStream(toImage);
                return imageFromBytes;
            }
            //Picture Save Methods Define Here. . 
            #region
            private void SaveImage(byte[] imageBytes2Save)
            {
                string Query_ = "INSERT INTO ForImage (ID,FileImage) VALUES (86,@0);";
                SQLiteParameter PicParam = new SQLiteParameter("@0", DbType.Binary);
                PicParam.Value = imageBytes2Save;
    
                con.Open();
                SQLiteCommand cmd = new SQLiteCommand(Query_,con);
                cmd.Parameters.Add(PicParam);
                cmd.ExecuteNonQuery();
                con.Close();
            }
    
            private byte[] Image2Byte(Image imageToconvert)
            {
                MemoryStream memoryStream = new MemoryStream();
                imageToconvert.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytesOfImage = memoryStream.ToArray();
                return bytesOfImage;
            }
    
            #endregion
    
           
    
    
        }
    }
