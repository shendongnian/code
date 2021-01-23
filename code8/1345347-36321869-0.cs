            static void Main(string[] args)
            {
                List<List<int>> results = new  List<List<int>>() {//Each number is a scorer's score
                              new List<int>(){ 4, 7, 9, 3, 8, 6},//competitor 1
                              new List<int>(){ 4, 8, 6, 4, 8, 5},//competitor 2
                              new List<int>(){ 2, 1, 10, 10, 10, 10}
                             };
                var max = results.Select((x, i) => new
                {
                    total = x.Sum(),
                    index = i
                }).OrderByDescending(x => x.total).Take(1);
            }
