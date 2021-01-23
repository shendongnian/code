    protected virtual void SendEvent(LogLevel level, string message, Exception exception, string memberName = null)
        {
            var logEvent = new LogEventInfo(level, _name, message);
            logEvent.Exception = exception;
            foreach (String key in _properties.Keys)
            {
                logEvent.Properties[key] = _properties[key];
            }
            _logger.Log(logEvent);
        }
