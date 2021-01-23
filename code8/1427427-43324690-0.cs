    public class CutomAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            string renderedMessage = base.RenderLoggingEvent(loggingEvent);
            ILayout layout = base.Layout;
            // do something here
        }
    }
