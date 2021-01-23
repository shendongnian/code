    namespace MyLogger
    {
        public class DebugListener :TraceListener
        {
            string LogFileName;
            public DebugListener (string filename)
            {
                filename = filename.Replace("@date",DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString());
                LogFileName = filename;
            }
        }
    }
