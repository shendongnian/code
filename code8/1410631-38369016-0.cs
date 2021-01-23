    private void DeterminePostPieceIsVisited(Position position, IEnumerable<Postpieces> postPieces)
    {
        foreach (var postPiece in postPieces)
        {
            if (postPiece.Deliverd)
                continue;
    
            var distanceToClosestPosition = postPiece.GPS.Distance(position.GPS);
    
            var delivered = distanceToClosestPosition.HasValue && IsInRadius(distanceToClosestPosition.Value);
            if(delivered)
                postPiece.Deliverd = true;
        }
    }
