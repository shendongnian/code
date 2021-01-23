    public partial class Form1 : Form {
        TextBox[,] textBoxes;
        int[,] values;
        public Form1() {
            InitializeComponent();
            textBoxes = new TextBox[4, 4];
            values = new int[textBoxes.GetLength(0), textBoxes.GetLength(1)];
            for(int r = 0; r < textBoxes.GetLength(0); r++) {
                for(int c = 0; c < textBoxes.GetLength(1); c++) {
                    values[r, c] = int.Parse(textBoxes[r, c].Text);
                }
            }
        }
    }
