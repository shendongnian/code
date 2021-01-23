    namespace CommTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            NetComm.Host host = new NetComm.Host(10010);
            NetComm.Client client1 = new NetComm.Client();
            NetComm.Client client2 = new NetComm.Client();
            private void Form1_Load(object sender, EventArgs e)
            {
                host.StartConnection();
                client1.Connect("localhost", 10010, "Jack");
                byte[] buffer = imageToByteArray(Image.FromFile("Bitmap1.bmp"));
                client2.Connect("localhost", 10010, "Jack2");
                client2.DataReceived += client2_DataReceived;
                client1.SendData(buffer, "Jack2");
            }
            void client2_DataReceived(byte[] Data, string ID)
            {
                Stream stream = new MemoryStream(Data); // Data is byte array 
                pictureBox1.Image = Image.FromStream(stream);
                pictureBox1.Refresh();
            }
            public byte[] imageToByteArray(Image imageIn)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, ImageFormat.Gif);
                return ms.ToArray();
            }
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                client1.Disconnect();
                host.CloseConnection();
            }
        }
    }
