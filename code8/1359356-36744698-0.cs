    return _requestRepository.ExecuteProcReader(myRequest,new SqlParameter("@userName", user)).Select(items => new Feed
    {
    Id = (int)items[0],
    Title = items[1].ToString(),
    Body = items[2].ToString(),
    Link = items[3].ToString(),
    PubDate = ((DateTime)items[4]).HasValue ? (DateTime) items[4] : DateTime.Now
    //Or any date you want to use
    });
