    public class Emails : Emails<String, String>
    {
        public Emails()
        {
        }
        public Emails(IList<Email> initialList) : base(initialList.ToMyList())
        {
            // getting error on the 'base' call since there is no signature similar to Emails(IList<Email> initialList)
            // how can I convert the parameter IList<Email> initialList to an IList<Email<String, String>>
        }
        public Emails(CollectionBase<Email> initialList) : base(initialList.ToMyCollection())
        {
            // getting error on the 'base' call since there is no signature similar to Emails(CollectionBase<Email> initialList)
            // how can I convert the parameter CollectionBase<Email> initialList to a CollectionBase<Email<String, String>>
        }
    }
