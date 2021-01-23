    public static bool eventLinker<T, Y>(T listener, Y speaker, string eventName, string eventHandler)
	{
		EventInfo eInfo = typeof(Y).GetEvent(eventName);
		Type handlerType = eInfo.EventHandlerType;
		if (eInfo != null && handlerType != null)
		{
			Delegate d = Delegate.CreateDelegate(handlerType, listener, eventHandler, false, false);
			if (d != null)
			{
				eInfo.AddEventHandler(speaker, d);
				return true;
			}
		}
		return false;
	}
