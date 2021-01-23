    if (playerTransform.position.z - safeZone > (spawnZ - amtOfTilesOnScreen * tileLength)) {
        if (activeTiles.Count() < (NumberOfTilesThatFitOnScreen + 1)) {
            var spawnedTile = SpawnTileAtFront();
            activeTiles.Add(spawnedTile);
        } else {
            var movedTile = activeTiles[0];
            MoveTileToFront(movedTile);
            //Puts the moved tile at the end of the array, so the next tile that will be moved is always the one in back
            activeTiles.RemoveAt(0);
            activeTiles.Add(movedTile);
        }
    }
