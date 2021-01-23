            List<int?> lst = maxNum.ToList<int?>();
            foreach (var item in lst)
            {
                if (item.HasValue)
                {
                    string str = item.Value.ToString();
                    // str has the value
                }
            }
