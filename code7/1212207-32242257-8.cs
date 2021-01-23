    class CellRelation
    {
        public DataGridViewCell SourceCell;
        public DataGridViewCell DestinationCell;
        public CellFormula Formula;
    }
    class CellFormula
    {
        public Func<DataGridViewCell, DataGridViewCell, decimal> Operator;
        public DataGridViewCell Operand1;
        public DataGridViewCell Operand2;
        public decimal Evaluate()
        {
            return Operator(Operand1, Operand2);
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<CellRelation> cellRelations = new List<CellRelation>();
        private void Initialise_Click(object sender, EventArgs e)
        {
            var soldCell = this.dataGridView1[1, 0];
            var remainingCell = this.dataGridView1[2, 0];
            var totalCell = this.dataGridView1[0, 0];
            // datagid values --- In your case this is from a dataset
            totalCell.Value = 10;
            soldCell.Value = 0;
            remainingCell.Value = 10;
            // initialise the relation / formula
            CellRelation relation = new CellRelation();
            relation.SourceCell = soldCell;
            relation.DestinationCell = remainingCell; // thats the dependent cell
            relation.Formula = new CellFormula();
            // here is a sample of subtraction formula :  Subtracting Sold items for total items
            relation.Formula.Operator = new Func<DataGridViewCell, DataGridViewCell, decimal>((p, v) => { return ((decimal.Parse(p.Value.ToString()))) - ((decimal.Parse(v.Value.ToString()))); });
            relation.Formula.Operand1 = totalCell;
            relation.Formula.Operand2 = soldCell;
            cellRelations.Add(relation);
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //look up if there is an destination cell for the cell being updated 
            var cellReln = cellRelations.FirstOrDefault(item => item.SourceCell.RowIndex == e.RowIndex && item.SourceCell.ColumnIndex == e.ColumnIndex);
            if (cellReln != null)
            {
                cellReln.DestinationCell.Value = cellReln.Formula.Evaluate();
            }
        }
