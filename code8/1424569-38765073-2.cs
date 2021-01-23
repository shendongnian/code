    abstract class Book : Product
    {
        public int PagesCount { get; set; }
    }
    class ProgrammingBook : Book
    {
        public string ProgrammingLanguage { get; set; }
        protected override int InternalSortOrder
        {
            get { return 1; }
        }
    }
    class CulinaryBook : Book
    {
        public string MainIngridient { get; set; }
        protected override int InternalSortOrder
        {
            get { return 2; }
        }
    }
    class EsotericBook : Book
    {
        public int MininumAge { get; set; }
        protected override int InternalSortOrder
        {
            get { return 3; }
        }
    }
    abstract class Disc : Product
    {
        internal enum Content
        {
            Music,
            Video,
            Software
        }
        public Content DiscContent { get; set; }
    }
    class CdDisc : Disc
    {
        protected override int InternalSortOrder
        {
            get { return 1; }
        }
    }
    class DvdDisc : Disc
    {
        protected override int InternalSortOrder
        {
            get { return 2; }
        }
    }
