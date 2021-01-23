        public ArrayList GetNums(int min, int max, ArrayList arr)
        {
            var results = new ArrayList();
            //nothing in the arr?
            if (arr.Count == 0)
                return results;
            //arr has only one list inside
            if(arr.Count == 1)
            {
                foreach(int a in (ArrayList)arr[0])
                {
                    if(a >= min && a <= max)
                    {
                        var r = new ArrayList();
                        r.Add(a);
                        results.Add(r);
                    }
                }
                return results;
            }
            //arr has two or more lists inside
            ArrayList firstList = (ArrayList)arr[0];
            ArrayList remainingArr = new ArrayList();
            for(int i = 1; i < arr.Count; i++)
            {
                remainingArr.Add(arr[i]);
            }
            foreach (int a in firstList)
            {
                var tempResults = GetNums(min - a, max - a, remainingArr);
                foreach(ArrayList result in tempResults)
                {
                    var newResult = new ArrayList();
                    newResult.Add(a);
                    newResult.AddRange(result);
                    results.Add(newResult);
                }
            }
            return results;
        }
