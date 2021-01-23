    var players = new List<int[]>() { new int[] { 0, 726, 1084, 0, 0, 5 }, new int[] { 2, 1481, 2208, 0, 0, -1 } };
    List<int[]> coords = new List<int[]>();
    for (int i = 1000; i <= 8000; i = i + 2300)
        for (int j = 1000; j <= 15000; j = j + 2000)
            coords.Add(new int[2] { j, i });
    coords.RemoveAll(x => 3500 >= getDist(0, 0, x[0], x[1]));
    coords.RemoveAll(x => 3500 >= getDist(16000, 9000, x[0], x[1]));
    var closestPoints =
        from playerIdx in Enumerable.Range(0, players.Count())
        let player = players[playerIdx]
        from coordIdx in Enumerable.Range(0, coords.Count())
        let theseCoords = coords[coordIdx]
        orderby getDist(theseCoords[0], theseCoords[1], player[1], player[2])
        select new { playerIdx, coordIdx };
    var playerCoords = new Dictionary<int, int>();
    var usedPlayers = new HashSet<int>();
    var usedCoords = new HashSet<int>();
    foreach (var pairing in closestPoints)
    {
        if (!usedPlayers.Contains(pairing.playerIdx)
            && !usedCoords.Contains(pairing.coordIdx))
        {
            playerCoords[pairing.playerIdx] = pairing.coordIdx;
            usedPlayers.Add(pairing.playerIdx);
            usedCoords.Add(pairing.coordIdx);
        }
    }
    
    // Result is in playerCoords as { 0: 0, 1: 6 }
