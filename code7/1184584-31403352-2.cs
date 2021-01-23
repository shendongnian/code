    public void Test()
        {
            var listU = new List<List<int>>
            {
                new List<int> {54, 86},
                new List<int> {112, 217},
                new List<int> {292, 325},
                new List<int> {402, 451},
                new List<int> {628, 664}
            };
            var listH = new List<List<int>>
            {
                new List<int> {129, 214},
                new List<int> {297, 321},
                new List<int> {406, 447},
                new List<int> {637, 664}
            };
            GetWindows(listU, listH);
        }
    static List<List<int>> GetWindows(List<List<int>> listU, List<List<int>> listH)
        {
            List<List<int>> list3 = new List<List<int>>();
            var startingOfH = listH.First()[0];
            var endOfH = listH.Last()[listH.Last().Count - 1];
            foreach (var num in listU)
            {
                var initial = num[0];
                var final = num[num.Count - 1];
                if (initial > startingOfH && final < endOfH)
                {
                    list3.Add(num);
                }
            }
            return list3;
        }
