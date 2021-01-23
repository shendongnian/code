    private static void CreateSection(ExcelRange basePosition)
    {
        var rangeToMerge = basePosition.Offset(0, 0, 5, 1);
        rangeToMerge.Merge = true;
    }
