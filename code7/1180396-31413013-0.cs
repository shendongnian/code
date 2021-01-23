    //using Microsoft.VisualStudio.TextManager.Interop;
    IVsTextManager textManager = GetService(typeof(SVsTextManager)) as IVsTextManager;
    if (textManager != null)
    {
        IConnectionPointContainer container = textManager as IConnectionPointContainer;
        if (container != null)
        {
            IConnectionPoint textManagerEventsConnection;
            Guid eventGuid = typeof(IVsTextManagerEvents).GUID;
            container.FindConnectionPoint(ref eventGuid, out textManagerEventsConnection);
            if (textManagerEventsConnection != null)
            {
                TextManagerEvents textManagerEvents = new TextManagerEvents();
                uint textManagerCookie;
                textManagerEventsConnection.Advise(textManagerEvents, out textManagerCookie);
                if (textManagerCookie != 0)
                {
                    textManagerEvents.FontColorPreferencesChanged += OnFontColorPreferencesChanged;
                }
            }
        }
    }
