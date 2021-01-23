    for (int i = 0; i < Lijst.Count; i++)
      {
       if (Lijst[i].scanned == false)
        {
         
         if (Lijst[i].price > (int)nudMinimum.Value)
          {
           Totaal++;
            lblDebug.Text = Totaal.ToString();
          }
    Lijst.RemoveAt(i);
        } 
      }
