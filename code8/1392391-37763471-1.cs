    for (int index = 0; index < splitLines.Length; index++)
            {
               itemsdata dataitem=new itemsdata
               {
                   txt0=splitLines[0];
                   txt1=splitLines[1];
                   txt2=splitLines[2];
                   txt2=splitLines[3];
                   txt2=splitLines[4];
               }
                items.Add(dataitem);
            }
    itemsControl.DataContext = items;
  
