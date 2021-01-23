    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace wfballs2
    {
        public partial class Form1 : Form
        {
           
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                int k = 0;
                PictureBox[] Shapes = new PictureBox[12];
                for (int i = 0; i < 12; i++)
                {
                    Shapes[i] = new PictureBox();
                    Shapes[i].Name = "ball" + i.ToString();
                    Shapes[i].Location = new Point(10 + 45 * i, 300);
                    Shapes[i].Size = new Size(40, 40);
                    Shapes[i].Image = Image.FromFile(@ "C:\Users\Eiko\Desktop\ball\ball.jpg");
                    Shapes[i].SizeMode = PictureBoxSizeMode.CenterImage;
                    Shapes[i].Visible = true;
                    this.Controls.Add(Shapes[i]);
                    Shapes[i].Paint += new PaintEventHandler((sender2, e2) =>
                    {
                        e2.Graphics.DrawString(k.ToString(), Font, Brushes.Black, 10, 13);
                        k++;
                    });
                }
            }
        }
    }
