    string data =
        @"item1 actived
         item2 none
         item special I none
         item special II actived";
    var result = data.Split('\n')
        .Select(item => {
            int lastSpace = item.LastIndexOf(' ');
            return new
            {
                Name = item.Substring(0, lastSpace).Trim(),
                Status = item.Substring(lastSpace, item.Length - lastSpace).Trim()
            }; }).ToList();
