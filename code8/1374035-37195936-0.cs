    abstract class ChapterBase<T> where T : ChapterBase<T>
    {
        public List<Page> pages;
    
        public ChapterBase()
        {
            pages = new List<Page>();
        }
    
        public T CalculatedChapter(DateTime date)
        {
            pages.ForEach(p => p.CalculatedPage(date));
            return (T)this;
        }
    
    }
    
    class Chapter :ChapterBase<Chapter>
    {
    }
    
    class EnhancedChapter : ChapterBase<EnhancedChapter>
    {
        public int? PageCount()
        {
            if (pages != null) return pages.Count; else return null;
        }
    }
