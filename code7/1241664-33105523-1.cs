    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {
            Height = 500;
            Width = 500;
    
            MyPanel myPanel = new MyPanel();
            myPanel.BackColor = Color.White;
            myPanel.BorderStyle = BorderStyle.FixedSingle;
            myPanel.Height = Height - 50;
            myPanel.Width = 200;
            myPanel.Top = 5;
            myPanel.Left = 5;
            Controls.Add(myPanel);
    
            var icon1 = Image.FromFile(@"path/to/file");  //Load the image FIRST
            MyPanel.Tile tile = new MyPanel.Tile(icon1);  //Pass it into the constructor
            tile.BackColor = Color.PowderBlue;
            myPanel.AddTile(tile);
    
            var icon2 = Image.FromFile(@"path/to/file");  //Again, image first
            MyPanel.Tile tile2 = new MyPanel.Tile(icon2); //Then construct
            tile2.BackColor = Color.PeachPuff;
            myPanel.AddTile(tile2);
        }    
    }
    
    class MyPanel : Panel
    {
        private const int TILEHEIGHT = 75;
        private static List<Panel> tileIndex = new List<Panel>();
           
        public MyPanel() { }
    
        public void AddTile(Tile tile)
        {
            tile.Width = this.Width;
            tile.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tile.Top = tileIndex.Count * TILEHEIGHT;
            tileIndex.Add(tile);
            this.Controls.Add(tile);
        }
    
        public class Tile : Panel
        {
            private PictureBox _picBox;
            // PROPERTY FOR IMAGE
            private Image _tileIcon;
            public Image TileIcon
            {
                get { return _tileIcon; }
                //Obviously needs additional logic for null images...
                set { _tileIcon = value; _picBox.Image = _tileIcon; }
            }
    
            public Tile(Image tileIcon = null)
            {
                _tileIcon = tileIcon;
                base.Height = TILEHEIGHT;
                base.Left = 0;
                base.Top = 0;
                base.BackColor = ColorTranslator.FromHtml("#FF5555");
    
                // Now this won't be null, and save a reference to the
                //_picBox so you can easily change the image later through
                //the icon property.
                _picBox = new PictureBox();
                _picBox.SizeMode = PictureBoxSizeMode.StretchImage;
                if (_tileIcon != null)
                { _picBox.Image = _tileIcon; }
                else
                { _picBox.Image = Image.FromFile(@"path/to/file"); }
    
                _picBox.Left = 5;
                _picBox.Top = 5;
                _picBox.Height = (this.Height - 10);
                _picBox.Width = _picBox.Height;
    
                this.Controls.Add(_picBox);
            }
        }
    }
