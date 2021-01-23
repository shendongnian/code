    public partial class Form1 : Form
    {
        //Guessing what the data type is:
        private int[,] _result;
    
        private void runAutomat_Click(object sender, EventArgs e)
        {
            //snip
            _result = cw.FillMatrix(myMatrix, size);
            this.Refresh();
        }    
    }
