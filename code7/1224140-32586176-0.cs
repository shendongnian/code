    public static class Helper
    {
       public static IEnumerable<byte> RemoveSubSequence(this IEnumerable<Byte> sequence, IEnumerable<Byte> subSequence)
       {
           List<byte> list = sequence.ToList();
           byte[] subSequenceList = subSequence.ToArray();    
           var index = -1; var count = 0;
           for(int i = 0; i < list.Count && index < 0; i++)
           {
               if (list[i] == subSequenceList[count]) count++; else count = 0;
               if (count == subSequenceList.Length) index = i - count;
           }
    
           list.RemoveRange(index, count);
           return list;
       }
    }
