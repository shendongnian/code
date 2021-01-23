        public partial class Form1 : Form
        {
            List<card> deck = new List<card>();
            public Form1()
            {
                InitializeComponent();
            }
        }
           public class card
        {
               string suit { get; set; }
               int rank { get; set; }
               Bitmap image { get; set; }
        }
    ​
