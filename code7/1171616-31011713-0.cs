    // It is assumed that DupInfo.CheckSum is nullable
    public void GetCRCs(List<DupInfo> dupInfos)
    {
      dupInfos[0].CheckSum = null ;        
      for (int i = 1; i < dupInfos.Count(); i++)
        {
           dupInfos[i].CheckSum = null ;
           if (dupInfos[i].Size == dupInfos[i - 1].Size)
           {
             if (dupInfos[i-1].Checksum==null) dupInfos[i-1].CheckSum = crc.ComputeChecksum(File.ReadAllBytes(dupInfos[i-1].FullName));
             dupInfos[i-1].CheckSum = crc.ComputeChecksum(File.ReadAllBytes(dupInfos[i-1].FullName));
           }
        }
    }
