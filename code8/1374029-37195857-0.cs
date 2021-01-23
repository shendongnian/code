    class EnhancedChapter : Chapter
    {
        public int? PageCount()
        {
            if (pages != null) return pages.Count; else return null;
        }
        public new EnhancedChapter CalculatedChapter(DateTime date) {
            return (EnhancedChapter)base.CalculatedChapter(date);
        }
    }
