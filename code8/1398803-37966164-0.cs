    public static class MyExtensions
    {
        public static void BubbleSort<T>(this List<T> list, Func<T, int> selector)
        {
            while (true)
            {
                bool changed = false;
                for (int i = 1; i < list.Count; i++)
                {
                    if (selector(list[i - 1]) > selector(list[i]))
                    {
                        T temp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = temp;
                        changed = true;
                    }
                }
                if (!changed)
                    break;
            }
        }
    }
