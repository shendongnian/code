    public static class ExcelExtensions
    {
        public static Range Named(this Range Cells, string CellName)
        {
            char cellLetter = CellName.Substring(0, 1).ToUpper()[0];
            int xCoordinate = (cellLetter - 'A') + 1;
            int yCoordinate = int.Parse(CellName.Substring(1));
            return Cells[yCoordinate, xCoordinate];
        }
    }
