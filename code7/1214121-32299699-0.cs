    using WFConsume.localhost;
    public partial class Form1 : Form
    {
        private int size;
        private localhost.Cell [][]cells;
        public Form1()
        {
            InitializeComponent();
            size = 10;
        }
    }
        private void runAutomat_Click(object sender, EventArgs e)
        {
            var myMatrix = new int[size][];
            for (int i = 0; i < size; i++)
            {
                myMatrix[i] = new int[size];
                for (int j = 0; j < size; j++)
                    myMatrix[i][j] = 0;
            }
            MyWebService cw = new MyWebService();
            cells = cw.FillMatrix(myMatrix, size);
           
        }
