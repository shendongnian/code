	public static void WriteFormat<T1, T2, T3>(this ILogTag tag, string format, T1 arg0, T2 arg1, T3 arg2
        , LogWithOptionalParameterList _ = default(LogWithOptionalParameterList)
		, [CallerMemberName] string callerMemberName = null, [CallerFilePath] string callerFilePath = null, [CallerLineNumber] int callerLineNumber = 0
		)
	{
		if (tag != null)
		{
			var entry = new LogEntry(DateTimeOffset.Now, tag.TagName, new LogString(format, new object[] { arg0, arg1, arg2 }), callerMemberName, System.IO.Path.GetFileName(callerFilePath), callerLineNumber);
			tag.Write(entry);
		}
	}
