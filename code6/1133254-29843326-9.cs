        static void Main(string[] args)
        {
            List<List<string>> GraphList = new List<List<string>>();
            GraphList.Add(new List<string>() { "0-2-37", "0-0-44", "0-1-28", "1-0-41", "1-2-44", "1-1-33" });
            GraphList.Add(new List<string>() { "2-2-37", "2-0-44", "2-1-28", "3-0-41", "3-2-44", "3-1-33" });
            GraphList.Add(new List<string>() { "4-2-37", "4-0-44", "4-1-28", "5-0-41", "5-2-44", "5-1-33" });
            for (int i = 0; i < GraphList.Count; i++)
            {
                GraphList[i] = GraphList[i].OrderBy(x =>
                {
                    var split = x.Split('-');
                    return split[1].PadLeft(5, '0') + split[0].PadLeft(5, '0');
                }).ToList();
            }
