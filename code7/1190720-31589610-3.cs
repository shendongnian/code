    List<int> stopWordArray = new List<int>();
    foreach (ListItem listItem in drplstGetDb.Items)
     {
         if (listItem.Selected)
          {
              stopWordArray.Add(Convert.ToInt32(listItem.Value.ToString()));
          }
     }
