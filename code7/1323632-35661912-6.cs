    public abstract class AbstractThing
    {
        public abstract string TheUserName { get; }
        public abstract string TheDescription { get; }
    }
    public class LivePost : AbstractThing
    {
        public string UserName { get; set; }
        public string PostDescription { get; set; }
        public override string TheUserName
        {
            get { return this.UserName; }
        }
        public override string TheDescription
        {
            get { return this.PostDescription; }
        }
    }
    public class LiveStream : AbstractThing
    {
        public string UserName { get; set; }
        public string Status { get; set; }
        public override string TheUserName
        {
            get { return this.UserName; }
        }
        public override string TheDescription
        {
            get { return this.Status; }
        }
    }
    public class AlternatingThingsViewModel
    {
        public ICollection<AbstractThing> AbstractThings { get; private set; }
        public AlternatingThingsViewModel(ICollection<LivePost> lps, ICollection<LiveStream> lss)
        {
            this.AbstractThings = new List<AbstractThing>();
            /* this is not correct...here is where you would "two by two" add items to the this.AbstractThings in the order you want.  the key is to have one collection exposed by the viewmodel */
            if (null != lps)
            {
                foreach (AbstractThing at in lps)
                {
                    this.AbstractThings.Add(at);
                }
            }
            if (null != lss)
            {
                foreach (AbstractThing at in lss)
                {
                    this.AbstractThings.Add(at);
                }
            }
        }
    }
