    public class ConsoleAppenderWithColorSwitching : ConsoleAppender
    {
        // forfeits the auto switch from Console.Error to Console.Out 
        // of the original appender :/
        protected override void Append(LoggingEvent loggingEvent)
        {
            var regex = new Regex(@"(\|\w+\|)");
            var renderedLayout = base.RenderLoggingEvent(loggingEvent);
            var chunks = regex.Split(renderedLayout);
            foreach (var chunk in chunks)
            {
                if (chunk.StartsWith("|") && chunk.EndsWith("|"))
                {
                    var consoleColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), chunk.Substring(1, chunk.Length - 2));
                    Console.ForegroundColor = consoleColor;
                }
                else
                {
                    Console.Write(chunk);
                }
            }
        }
    }
