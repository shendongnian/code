    int usedManyTimes = 0;
    for (int i = 0; i < hasResponseBeenUsedBefore.GetLength(1); i++)
    {
         MessageBox.Show(i.ToString());
         if (hasResponseBeenUsedBefore[1, i] == true)
         {                    
              usedManyTimes++;
         }
    }
