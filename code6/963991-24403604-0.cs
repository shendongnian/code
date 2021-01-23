        public class MyRollingFileAppender : log4net.Appender.RollingFileAppender
        {
            override protected void AdjustFileBeforeAppend()
            {
                if (RollingStyle == RollingMode.Date)
                {
                    // decide if should roll
                    if (shouldRoll)
                    {  
                        RollOverTime(true);
                    }
                }
                else
                {
                    base.AdjustFileBeforeAppend();
                }
            }
        }
