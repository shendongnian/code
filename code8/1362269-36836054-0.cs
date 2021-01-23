    public List<List<HexCoordinate>> GetsRingsSurroundingHex(HexCoordinate coordinate, int maxRings)
        {
            // reference: http://gamedev.stackexchange.com/questions/51264/get-ring-of-tiles-in-hexagon-grid
            // int ring = 1
            //   Travel around the ring by traversing N,SE,S,SW,NW,N,NE multiplied by the ring number
            //   ring++
            //      Travel Around ring again
            //      cont until desired ring...
            var hexRings = new List<List<HexCoordinate>>();
            // Add in the current hex to the list
            var currentHex = new List<HexCoordinate>();
            currentHex.Add(coordinate);
            hexRings.Add(currentHex);
            // Now go through and add the other rings
            while (hexRings.Count <= maxRings)
            {
                var ring = new List<HexCoordinate>();
                HexCoordinate tempCoordinate = coordinate;
                int currentRingNumber = hexRings.Count;
                // We start off by going north to the correct ring, and then adding it to our list
                for (int i = 0; i < currentRingNumber; i++)
                {
                    tempCoordinate = tempCoordinate.North();
                }
                ring.Add(tempCoordinate);
                // After that, we proceed to go clockwise around the ring until we come back to the start
                for (int i = 0; i < currentRingNumber; i++)
                {
                    tempCoordinate = tempCoordinate.SouthEast();
                    // If the ring is an odd number, you need to re-align the coordinates back to where whey should be
                    if (IntExtensions.IsOdd(i)) tempCoordinate = tempCoordinate.North();
                    ring.Add(tempCoordinate);
                }
                // The rightmost segment is east because we can go straight down the required number of times
                for (int i = 0; i < currentRingNumber; i++)
                {
                    tempCoordinate = tempCoordinate.South();
                    ring.Add(tempCoordinate);
                }
                // We utilize Current Ring - 1 because we only want this to run on rings that are greater than 1
                for (int i = 0; i < currentRingNumber - 1; i++)
                {
                    if (currentRingNumber.IsEven())
                    {
                        if (i.IsEven())
                            tempCoordinate = tempCoordinate.SouthWest();
                        else
                            tempCoordinate = tempCoordinate.West();
                    }
                    else
                    {
                        if (i.IsEven())
                            tempCoordinate = tempCoordinate.West();
                        else
                            tempCoordinate = tempCoordinate.SouthWest();
                    }
                    ring.Add(tempCoordinate);
                }
                // Coming into this statement, we are now at the bottom 3 coordinates.
                // Since our grid is laid out vertically, we can assume that these three hexes will be directly west of each other
                // So we only have to go west twice to make our way to the next north segment 
                for (int i = 0; i < 2; i++)
                {
                    tempCoordinate = tempCoordinate.West();
                    ring.Add(tempCoordinate);
                }
                // We utilize Current Ring - 1 because we only want this to run on rings that are greater than 1
                for (int i = 0; i < currentRingNumber - 1; i++)
                {
                    if (i.IsEven())
                        tempCoordinate = tempCoordinate.NorthWest();
                    else
                        tempCoordinate = tempCoordinate.West();
                    ring.Add(tempCoordinate);
                }
                // The left most segment is easy because we can just go straight up
                for (int i = 0; i < currentRingNumber; i++)
                {
                    tempCoordinate = tempCoordinate.North();
                    ring.Add(tempCoordinate);
                }
                // We utilize Current Ring - 1 because we only want this to run on rings that are greater than 1
                for (int i = 0; i < currentRingNumber - 1; i++)
                {
                    if (currentRingNumber.IsEven())
                    {
                        if (i.IsEven())
                            tempCoordinate = tempCoordinate.East();
                        else
                            tempCoordinate = tempCoordinate.NorthEast();
                    }
                    else
                    {
                        if (i.IsEven())
                            tempCoordinate = tempCoordinate.NorthEast();
                        else
                            tempCoordinate = tempCoordinate.East();
                    }
                    ring.Add(tempCoordinate);
                }
                // Finally, we add the ring to our system rings and loop until we no longer fit the criteria
                hexRings.Add(ring);
            }
            return hexRings;
        }
