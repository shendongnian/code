    static List<List<int>> GetWindows(List<List<int>> listU, List<List<int>> listH)
        {
            List<List<int>> list3 = new List<List<int>>();
            var startingOfH = listH.First()[0];
            var endOfH = listH.Last()[listH.Last().Count - 1];
            foreach (var num in listH)
            {
                var final = num[num.Count - 1];
                if (final > startingOfH && final < endOfH)
                {
                    list3.Add(num);
                }
            }
            return list3;
        }
