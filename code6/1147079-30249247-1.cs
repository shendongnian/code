       public static KeyValuePair<string, string> GetUserInfo(string username, SortedList<string, string> list)
        {
            int index = list.IndexOfKey(username);
            if(index == -1)
            {
                return new KeyValuePair<string, string>();
            }
            
            index = index == (list.Count - 1) ? 0 : index + 1;
            return list.ElementAt(index);
        }
