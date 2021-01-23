        private bool IsAnagram(string a, string b)
        {
            if (a.Length != b.Length) return false;
            List<char> list1 = a.ToList();
            List<char> list2 = b.ToList();
            for (int i = 0; i < a.Length; i++)
            {
                if (list2.Contains(list1[i])) // try to find inside list 1
                {
                    list2.Remove(list1[i]); // remove it from list 2
                }
                else
                {
                    return false; // didnt find any thing. so they are not anagram
                }
            }
            return true; // loop finished successfully. they are anagram
        }
