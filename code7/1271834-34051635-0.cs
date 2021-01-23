    protected virtual void OnReport(T value)
    {
            // If there's no handler, don't bother going through the [....] context.
            // Inside the callback, we'll need to check again, in case 
            // an event handler is removed between now and then.
            Action<T> handler = m_handler;
            EventHandler<T> changedEvent = ProgressChanged;
            if (handler != null || changedEvent != null)
            {
                // Post the processing to the [....] context.
                // (If T is a value type, it will get boxed here.)
                m_synchronizationContext.Post(m_invokeHandlers, value);
            }
    }
