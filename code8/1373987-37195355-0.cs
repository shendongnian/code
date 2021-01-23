    object[] array = new object[0];
    public void Insert(int index, object val)
        {
           Array.Resize(ref array, array.Length + 1);
    
            if (index >= array.Length-1)
            {
                array[array.Length - 1] = val;
                return;
            }
           
           for (int i = 0; i < array.Length; i++)
           {
               if (index == i)
               {
                   for (int idx = array.Length; idx > index; idx--)
                   {
                       array[idx-1] = array[idx-2];
                   }
                   array[i] = val;
                   return;
                }
            }
       }
