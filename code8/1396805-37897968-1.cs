    private RegenerationType AccquireRegenerationState (int floor, int playerFloor)
    {
        var entranceExists = floorBlocks[floor].doorBlocks.Count != 0;
        var whatever = floor + 1 == playerFloor || !floorBlocks[floor + 1].isVisited;
        if (whatever)
        {
            return entranceExists ? RegenerationType.Still : RegenerationType.Limit;
        }
        else
        {
            return entranceExists ? RegenerationType.Prime : RegenerationType.Full;
        }
    }
