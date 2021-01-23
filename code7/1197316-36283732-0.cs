    [Serializable]
    class CallbackContext
    {
        public string Code { get; set; }
        public void Entry()
        {
			Console.WriteLine("Creating thread");
			try
			{
				var scriptThread = new Thread(() =>
				{
					try
					{
						Console.WriteLine("Trying");
						AppDomain.CurrentDomain.SetData("result", CSharpScript.RunAsync(Code).ReturnValue.Result);
					}
					catch (Exception ex)
					{
						AppDomain.CurrentDomain.SetData("result", ex.Message);
					}
				});
				scriptThread.Start();
				if (!scriptThread.Join(6000))
				{
					scriptThread.Abort();
					AppDomain.Unload(AppDomain.CurrentDomain);
				}
			}
			catch (Exception ex)
			{
				AppDomain.CurrentDomain.SetData("result", ex.ToString());
			}
        }
    }
        ...
        object result = null;
        try {
            Console.WriteLine("Attempting to run in sandbox");
			CallbackContext ctx = new CallbackContext();
			ctx.Code = code;
            sandbox.DoCallBack(ctx.Entry);
			result = sandbox.GetData("result");
        }
        catch (Exception e)
        {
            result = e.ToString();
        }
