    public class AlternatingThingsViewModel
    {
        public ICollection<AbstractThing> AbstractThings { get; private set; }
        public AlternatingThingsViewModel(ICollection<LivePost> lps, ICollection<LiveStream> lss)
        {
            this.AbstractThings = new List<AbstractThing>();
            /* this is a "one by one" with no error checking if the counts are different */
            IEnumerator<AbstractThing> livePostEnum = null == lps ? null : lps.GetEnumerator();
            IEnumerator<AbstractThing> liveStreamEnum = null == lss ? null : lss.GetEnumerator();
            if (null != liveStreamEnum)
            {
                liveStreamEnum.MoveNext();
            }
            if (null != livePostEnum)
            {
                while (livePostEnum.MoveNext() == true)
                {
                    AbstractThing lpCurrent = livePostEnum.Current;
                    AbstractThing lsCurrent = null == liveStreamEnum ? null : liveStreamEnum.Current;
                    if (null != liveStreamEnum)
                    {
                        liveStreamEnum.MoveNext();
                    }
                    this.AbstractThings.Add(lpCurrent);
                    if (null != lsCurrent)
                    {
                        this.AbstractThings.Add(lsCurrent);
                    }
                }
            }
        }
    }
