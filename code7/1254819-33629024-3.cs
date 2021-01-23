    // Let's make a utility function:
    public static IEnumerable<Point> GetNeighboringPositions(Point position)
    {
        yield return new Point(position.X - 1, position.Y);
        yield return new Point(position.X, position.Y - 1);
        yield return new Point(position.X + 1, position.Y);
        yield return new Point(position.X, position.Y + 1);
    }
    // In the Board code:
    foreach (Point neighboringPosition in GetNeighboringPositions(currentPosition))
    {
        if (map.IsPassable(neighboringPosition.X, neighboringPosition.Y))
            startBlocks.Add(neighboringPosition);
    }
