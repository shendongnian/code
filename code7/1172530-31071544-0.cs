    class TracedErrorTarget : CompoundTargetBase
    {
        private int _head;
        private LogEventInfo[] _traceTail; // ring buffer
        protected override void Write(LogEventInfo logEvent)
        {
            if (logEvent.Level == LogLevel.Trace)
            {
                SaveTrace(logEvent);
                return;
            }
            if (logEvent.Level == LogLevel.Error)
            {
                LogEventInfo tracedLogEvent = PrepareTracedErrorEvent(logEvent);
                base.Write(tracedLogEvent);
                return;
            }
            base.Write(logEvent);
        }
        private void SaveTrace(LogEventInfo logEvent)
        {
            int traceDepth = _traceTail.Length;
            _traceTail[_head] = logEvent;
            _head = (_head + 1) % traceDepth;
        }
        private LogEventInfo PrepareTracedErrorEvent(LogEventInfo logEvent)
        {
            // prepare LogEventInfo with trace tail
            throw new System.NotImplementedException();
        }
    }
