    public void addAtLocation(int location, String element)
      {
        String[] newMyArray = new string[myArray.Length + 1];
        for (int oldIndex = 0, newIndex = 0; oldIndex <= myArray.Length - 1; oldIndex++, newIndex++)
        {
          
            if (newIndex == location)
            {
              newMyArray[oldIndex] = element;
              oldIndex--;
            }
            else
            {
              newMyArray[newIndex] = myArray[oldIndex];
            }
          }
        
        myArray = newMyArray;
      }
