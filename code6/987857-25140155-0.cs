        public static List<T> PaginateWithOffset<T>(List<T> list, int offset, int pageSize)
        {
            List<T> tempList = new List<T>();
            if (offset < 0 || pageSize < 0 || offset >= list.Count || list.Count == 0)
            {
                return list;
            }
            else
            {
                int endPage = offset + pageSize;
                int startPage = offset;
                if ((startPage < list.Count && endPage > list.Count) || (pageSize == 0))
                {
                    endPage = list.Count;
                }
                for (int i = startPage; i < endPage; i++)
                {
                    tempList.Add(list[i]);
                }
                return tempList;
            }
        }
