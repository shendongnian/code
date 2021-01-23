        private bool IsAnagram(string a, string b)
        {
            if (a.Length != b.Length) return false;
            List<char> list1 = a.ToList();
            List<char> list2 = b.ToList();
            for (int i = 0; i < a.Length; i++)
            {
                // try to remove list 1 item from list 2
                // if didn't find any thing to remove. so they are not anagram
                if (!list2.Remove(list1[i])) return false;
            }
            return true; // loop finished successfully. they are anagram
        }
