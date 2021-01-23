         lst.Sort((s1, s2) =>
         {
              string first = new string(s1.TakeWhile(c => char.IsDigit(c)).ToArray());
              string second = new string(s2.TakeWhile(c => char.IsDigit(c)).ToArray());
              return int.Parse(first).CompareTo(int.Parse(second));
         });
