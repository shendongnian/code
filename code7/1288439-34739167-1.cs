    public partial class Form1 : Form
    {
        public Form1(NetComm.Client client)
        {
            _client = client;
            InitializeComponent();
        }
        
        // there is a button to broadcast picture on the client.
        private void Button1_Click(object sender, EventArgs e)
        {
            // update the image that should be broadcasted as You like.
            _client.SendData(imageToByteArray(Image.FromFile("Bitmap1.bmp")));
        }
        NetComm.Client _client;
        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Click += Button1_Click;
            _client.DataReceived += client_DataReceived;
        }
        void client_DataReceived(byte[] Data, string ID)
        {
            Stream stream = new MemoryStream(Data); // Data is byte array 
            pictureBox1.Image = Image.FromStream(stream);
        }
        public byte[] imageToByteArray(Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Gif);
            return ms.ToArray();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _client.Disconnect();
        }
    }
