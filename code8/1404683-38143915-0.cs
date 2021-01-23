        (from chapter in Chapters
        join userChapter in UserChapters on chapter.Id equals    userChapter.ChapterId
        join pub in Publications on chapter.Id equals pub.ChapterId into P 
        from pub in P.DefaultIfEmpty()
        where userChapter.UserId == 9
        group pub by new { chapter.Id, chapter.Name,chapter.Logo,pub.Id} into x
                           orderby x.Key.Name
        select new 
       {
           Id = x.Key.Id,
           chapterName = x.Key.Name,
           Logo = x.Key.Logo,
	   PublicationCount=x.Count()
       }
)
