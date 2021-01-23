    public List<Point> GetReachableTiles(Point currentPosition, int maxDistance)
    {
        List<Point> coveredTiles = new List<Point> { currentPosition };
        List<Point> boundaryTiles = new List<Point> { currentPosition };
        for (int distance = 0; distance < maxDistance; distance++)
        {
            List<Point> nextBoundaryTiles = new List<Point>();
            foreach (Point position in boundaryTiles)
            {
                foreach (Point pos in GetNeighboringPositions(position))
                {
                    // You may also want to check against other player positions, if players can block each other:
                    if (!coveredTiles.Contains(pos) && !boundaryTiles.Contains(pos) && map.IsPassable(pos.X, pos.Y))
                    {
                        // We found a passable tile:
                        coveredTiles.Add(pos);
                        // And we want to check its neighbors in the next 'distance' iteration, too:
                        nextBoundaryTiles.Add(pos);
                    }
                }
            }
            // The next 'distance' iteration should check the neighbors of the current boundary tiles:
            boundaryTiles = nextBoundaryTiles;
        }
        return coveredTiles;
    }
