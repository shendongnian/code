    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public float RedUntil { get; set; }
        public float YellowUntil { get; set; }
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }
    }
