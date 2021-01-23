    public class Form2 : XtraForm
    {
        private GridView grid;
        public Form2(GridView grid)
        {
            this.grid = grid;
        }
        private void somebutton_Click(object sender, EventArgs e)
        {
            grid.FocusedRowHandle = ...
        }
    }
