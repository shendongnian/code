    var filesSetsWithPossibleDupes = files.GroupBy(f => f.Length)
                                          .Where(group => group.Count() > 1);
    foreach (var grp in filesSetsWithPossibleDupes)
    {
        var checksums = new List<CRC32CheckSum>(); //or whatever type
        foreach (var file in grp)
        {
            var currentCheckSum = crc.ComputeChecksum(file);
            if (checksums.Contains(currentCheckSum))
            {
                //Found a duplicate
            }
            else
            {
                checksums.Add(currentCheckSum);
            }
        }
    }
