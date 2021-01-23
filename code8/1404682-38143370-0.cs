        (from chapter in Chapters
        join userChapter in UserChapters on chapter.Id equals    userChapter.ChapterId
        join pub in Publications on chapter.Id equals pub.ChapterId into P 
        from publication in P.DefaultIfEmpty()
        where userChapter.UserId == 9
        group new
                           {
                               PubID = publication.Id,
                               Logo = chapter.Logo
                           } by new { chapter.Id, chapter.Name} into x
                           orderby x.Key.Name
        select new 
       {
           Id = x.Key.Id,
           chapterName = x.Key.Name,
           Logo = x.Max(z=>z.Logo.Count())
       }
)
