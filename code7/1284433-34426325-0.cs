            string str = @"128 2 2 0 24 49 50 46
    129 4 2 0 26 51 36 54 53
    
    130 4 2 0 26 51 41 52 56";
            string[] strSplitted = str.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            List<string> result = strSplitted.ToList();
            foreach (var item in strSplitted)
            {
                if (!item.Contains("4 2 0"))
                {
                    result.Remove(item);
                }
            }
