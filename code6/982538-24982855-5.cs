    public void SortList(List<string> thread)
            {
                thread.OrderBy(s =>
                {
                    int num;
                    var parts = string.Split(s, '.');
                    if (parts.Count > 0 && int.TryParse(parts[0], out num))
                        return num;
    
                    return int.MaxValue;
                });
            }
