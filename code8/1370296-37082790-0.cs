    public partial class Form1 : Form
    {
        int[,] array2d;
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.array2d=ParseArray(textBox1.Lines, 4, 4);
        }
        public static int[,] ParseArray(string[] lines, int rows, int columns)
        {
            // allocate empty array
            var array=new int[rows, columns];
            // for each row of text
            for (int row=0; row<rows; row++)
            {
                // split into values separated by spaces, tabs, commas, or semicolons
                var items=lines[row].Split(',', ' ', ';', '\t');
                // for each value in the row
                for (int col=0; col<columns; col++)
                {
                    // parse the string into an integer _safely_
                    int x=0;
                    int.TryParse(items[col], out x);
                    array[row, col]=x;
                }
            }
            return array;
        }
        public static int[,] ParseArray(string text, int rows, int columns)
        {
            // split text into lines
            var lines=text.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return ParseArray(lines, rows, columns);
        }
    }
