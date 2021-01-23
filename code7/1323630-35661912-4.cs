    public class AlternatingThingsViewModel
    {
        public ICollection<AbstractThing> AbstractThings { get; private set; }
        public AlternatingThingsViewModel(ICollection<LivePost> lps, ICollection<LiveStream> lss)
        {
            this.AbstractThings = new List<AbstractThing>();
            /* this is a "one by one" with no error checking if the counts are different */
            IEnumerator<AbstractThing> LivePostEnum = lps.GetEnumerator();
            IEnumerator<AbstractThing> LiveStreamEnum = lss.GetEnumerator();
            LiveStreamEnum.MoveNext();
            while (LivePostEnum.MoveNext() == true)
            {
                AbstractThing lpCurrent = LivePostEnum.Current;
                AbstractThing lsCurrent = LiveStreamEnum.Current;
                LiveStreamEnum.MoveNext();
                this.AbstractThings.Add(lpCurrent);
                if (null != lsCurrent)
                {
                    this.AbstractThings.Add(lsCurrent);
                }
            }
        }
    }
