            List<int> data = new List<int> { 1, 2, 1, 2, 3,3, 1, 2, 3, 4, 1, 2, 3, 4, 5, 6 };
            List<List<int>> resultLists = new List<List<int>>();
            int last = 0;
            int count = 0;
            var res = data.Where((p, i) =>
            {
                if (i > 0)
                {
                    if (p > last && p!=last)
                    {
                        resultLists[count].Add(p);
                    }
                    else
                    {
                        count++;
                        resultLists.Add(new List<int>());
                        resultLists[count].Add(p);
                    }
                }
                else
                {
                    resultLists.Add(new List<int>());
                    resultLists[count].Add(p);
                }
              
               
                last = p;
                return true;
            }).ToList();
