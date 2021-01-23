    private static IEnumerable<string> VisitCell(int row, int column, bool[,] visited)
    {
        if (row < 0 || column < 0 || row >= maze.GetLength(0) || column >= maze.GetLength(1))
            yield break;
        if (maze[row, column] == '#' || visited[row, column])
            yield break;
        if (row == 0 || row == maze.GetLength(0) - 1 ||
            column == 0 || column == maze.GetLength(1) - 1)
        {
            yield return maze[row, column].ToString();
        }
        visited[row, column] = true;
        foreach (var path in VisitCell(row, column + 1, visited))
        {
            yield return maze[row, column] + path;
        }
        foreach(var path in VisitCell(row, column - 1, visited))
        {
            yield return maze[row, column] + path;
        }
        foreach (var path in VisitCell(row + 1, column, visited))
        {
            yield return maze[row, column] + path;
        }
        foreach (var path in VisitCell(row - 1, column, visited))
        {
            yield return maze[row, column] + path;
        }
        visited[row, column] = false;
    }
