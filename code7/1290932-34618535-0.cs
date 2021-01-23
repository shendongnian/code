    public static void RegisterClickEvent(EventHandler<EventArgs> method)
	{
		Click += new EventHandler<EventArgs>(method);
	}
    ...
    RegisterClickEvent(Method);
