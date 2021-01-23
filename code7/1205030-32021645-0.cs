    class Program
    {
        static void Main(string[] args)
        {
            var list = new[] { 11, 2, 4, 6 };
            var target = 13;
            var n = list.Length;
            var result = KnapSack(target, list, n);
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
        private static List<int> KnapSack(int target, int[] val, int n)
        {
            var d = new int[n + 1, target + 1];
            var p = new int[n + 1, target + 1];
            for (var i = 0; i <= n; i++)
            {
                for (var c = 0; c <= target; c++)
                {
                    p[i, c] = -1;
                }
            }
            for (int i = 0; i <= n; i++)
            {
                for (int c = 0; c <= target; c++)
                {
                    if (i == 0 || c == 0)
                    {
                        d[i, c] = 0;
                    }
                    else
                    {
                        var a = d[i - 1, c];
                        if (val[i - 1] <= c)
                        {
                            var b = val[i - 1] + d[i - 1, c - val[i - 1]];
                            if (a > b)
                            {
                                d[i, c] = a;
                                p[i, c] = p[i - 1, c];
                            }
                            else
                            {
                                d[i, c] = b;
                                p[i, c] = i - 1;
                            }
                        }
                        else
                        {
                            d[i, c] = a;
                            p[i, c] = p[i - 1, c];
                        }
                    }
                }
            }
            //sum
            //Console.WriteLine(d[n, target);
            //restore set
            var resultSet = new List<int>();
            var m = n;
            var s = target;
            var t = p[m, s];
            while (t != -1)
            {
                var item = val[t];
                resultSet.Add(item);
                m--;
                s -= item;
                t = p[m, s];
            }
            return resultSet;
        }
    }
