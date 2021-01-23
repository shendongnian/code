    `List<MenuItem> a = new List<MenuItem>();
     for (int i = 0; i < boardSize; i++)
     {
         var item = new MenuItem();
         item.Header = (i + 1).ToString();
         item.Click += item_Click;
         a.Add(item);
     }`        
