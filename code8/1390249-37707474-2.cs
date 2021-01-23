           //  Use your Uow.Gems.GetAll() list of gems 
            string[] gems = new string[] { "F12", "T16", "K15", "F10", "K14", "T9", "T7", "A12", "A11" };
            string input = "T9";
            //Cache it something like this Uow.Gems.GetAll().OrderBy(x => x, new GemComparer()).ToList()
            var cacheGems = gems.OrderBy(x => x, new GemComparer()).ToList().Select((Value, Index) => new { Value, Index });
            foreach (var thing in cacheGems)
            {
                Console.WriteLine(thing);
            }
            var index = cacheGems.Where(o => o.Value == input).Select(x => x.Index - 1);
            Console.WriteLine(index.FirstOrDefault());
        public class GemComparer : IComparer<string>
        {
            public int Compare(string s1, string s2)
            {
                if (IsNumeric(s1) && IsNumeric(s2))
                {
                    if (Convert.ToInt32(s1) > Convert.ToInt32(s2)) return 1;
                    if (Convert.ToInt32(s1) < Convert.ToInt32(s2)) return -1;
                    if (Convert.ToInt32(s1) == Convert.ToInt32(s2)) return 0;
                }
                if (IsNumeric(s1) && !IsNumeric(s2))
                    return -1;
                if (!IsNumeric(s1) && IsNumeric(s2))
                    return 1;
                return string.Compare(s1, s2, true);
            }
            public static bool IsNumeric(object value)
            {
                try
                {
                    int i;
                    return int.TryParse(value.ToString(), out i);
                }
                catch (FormatException)
                {
                    return false;
                }
            }
        }
