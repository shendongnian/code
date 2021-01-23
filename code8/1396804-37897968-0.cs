    private RegenerationType AccquireRegenerationState (int floor, int playerFloor)
    {
        var entranceExists = floorBlocks[floor].doorBlocks.Count != 0;
        var whatever = floor + 1 == playerFloor || !floorBlocks[floor + 1].isVisited;
        RegenerationType type;
        if (whatever)
        {
            type = entranceExists ? RegenerationType.Still : RegenerationType.Limit;
        }
        else
        {
            type = entranceExists ? RegenerationType.Prime : RegenerationType.Full;
        }
        return type;
    }
