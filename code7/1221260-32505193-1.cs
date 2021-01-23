    DbContext.Musics()         
         .Select(m => new MyComplexType()
         {
                MyMusic = m,
                Author = m.Author,
                blablabla = ...
         })
