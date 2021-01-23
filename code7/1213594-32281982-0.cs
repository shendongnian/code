    public static class ExcelExtensions
    {
        public static Range Named(this Range Cells, string CellName)
        {
            //I'm assuming A1 would be [0,0], if not, adjust the displacement.
            char cellLetter = CellName.Substring(0, 1).ToUpper()[0];
            int xCoordinate = cellLetter - 'A';
            int yCoordinate = int.Parse(CellName.Substring(1)) - 1;
            return Cells[xCoordinate, yCoordinate];
        }
    }
