      public string ConvertToString(ListView l)
      {
         StringBuilder list = new StringBuilder();
   
         foreach (string item in listView.Items)
            list.AppendLine(item);
         return list.ToString();
      }
