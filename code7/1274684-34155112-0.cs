    public class FilteredAppender : AppenderSkeleton
    {
        private IFilter filter;
        protected override bool FilterEvent(LoggingEvent loggingEvent)
        {
            IFilter f = this.FilterHead;
            while (f != null)
            {
                if (f.Decide(loggingEvent) == FilterDecision.Accept)
                {
                    filter = f; // Set the filter field
                    break;
                }
                f = f.Next;
            }
            return base.FilterEvent(loggingEvent);
        }
        protected override void Append(LoggingEvent loggingEvent)
        {
            NamedFilter acceptedfilter = filter as NamedFilter;            
            
            if (acceptedfilter!= null)
            {
                  var somename = acceptedfilter.MyName;
                  // etc
            }
        }
    }
