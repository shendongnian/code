    public interface ICard<T>
    {
        T[,] GetCells();
        T GetCell(int row, column);
    }
