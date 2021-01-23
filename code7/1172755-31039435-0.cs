      public SumList(int[] list)
      {
         List<int> listInteger = new List<int>();
         for (int i = 0; i < list.Length; i++)
            listInteger.Add(list[i]);
         StringBuilder output = new StringBuilder();
         sum(listInteger, output);
         Console.WriteLine(output.ToString());
      }
      private double sum(List<int> list, StringBuilder output)
      {
         if (list.Count == 1)
         {
            return list[0];
         }
         if (list.Count == 2)
         {
            output.Append(printList(list));
            output.Append((list[0] + list[1])).Append(Environment.NewLine);
            return list[0] + list[1];
         }
         double last = list[list.Count - 1];
         List<int> backupList = new List<int>(list);
         list.RemoveAt(list.Count - 1);
         double s = last + sum(list, output);
         output.Insert(0, Environment.NewLine);
         output.Insert(0, s);
         output.Insert(0, printList(backupList));
         return s;
      }
      private string printList(List<int> list)
      {
         string result = "";
         for (int i = 0; i < list.Count; i++)
         {
            result += list[i];
            if (i != list.Count - 1)
            {
               result += " + ";
            }
            else
            {
               result += " = ";
            }
         }
         return result;
      }
