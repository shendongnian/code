    namespace Booster_pack_2
    {
    public partial class Form3 : Form
    {
        List<Image> Images1;
        public Form3()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Images1 = new List<Image>();
            ResourceManager rm = Booster_pack_2.Properties.Resources.ResourceManager;
           string index1 = textBox1.Text;
            Bitmap image1 = (Bitmap)rm.GetObject(index1);
            pictureBox1.Image = image1;
            Images1.Add((Image)Booster_pack_2.Properties.Resources.ResourceManager.GetObject(index1));
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ResourceManager rm = Booster_pack_2.Properties.Resources.ResourceManager;
            string index2 = textBox2.Text;
            Bitmap image2 = (Bitmap)rm.GetObject(index2);
            pictureBox2.Image = image2;
            Images1.Add((Image)Booster_pack_2.Properties.Resources.ResourceManager.GetObject(index2));
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            ResourceManager rm = Booster_pack_2.Properties.Resources.ResourceManager;
            string index3 = textBox3.Text;
            Bitmap image3 = (Bitmap)rm.GetObject(index3);
            pictureBox3.Image = image3;
            Images1.Add((Image)Booster_pack_2.Properties.Resources.ResourceManager.GetObject(index3));
        }
