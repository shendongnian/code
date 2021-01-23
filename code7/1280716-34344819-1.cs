    private static World GetWorldFromMappedMemory()
    {
       string str;
    
       using (var mut = Mutex.OpenExisting(PastGenerationListBox.SELECTEDWORLD_MUTEX_NAME))
       {
          mut.WaitOne();
    
          using (var sharedMem = MemoryMappedFile.OpenExisting(PastGenerationListBox.SELECTEDWORLD_MEMORY_NAME))
          {
             using (var stream = sharedMem.CreateViewStream())
             {
                byte[] rawLen = new byte[4];
                stream.Read(rawLen, 0, 4);
                var len = BitConverter.ToInt32(rawLen, 0);
    
                byte[] rawData = new byte[len];
                stream.Read(rawData, 0, rawData.Length);
                str = Encoding.ASCII.GetString(rawData);
             }
          }
    
          mut.ReleaseMutex();
       }
    
       return WorldSerialize.DeserializeWorldFromString(str);
    }
