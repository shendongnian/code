    [Serializable]
    public class HandleExceptionsAttribute : OnExceptionAspect {
	    /// <summary>
	    /// Initializes a new instance of the <see cref="HandleExceptionsAttribute"/> class.
	    /// </summary>
	    public HandleExceptionsAttribute() {
		    AspectPriority = 1;
	    }
	
	    public override void OnException(MethodExecutionArgs args) {
		    //Suppress the current transaction to ensure exception is not rolled back
		    using (var s = new TransactionScope(TransactionScopeOption.Suppress)) {
			    //Log exception
			    using (var exceptionLogContext = new ExceptionLogContext()) {
				    exceptionLogContext.Set<ExceptionLogEntry>().Add(new ExceptionLogEntry(args.Exception));
				    exceptionLogContext.SaveChanges();
			    }
		    }
	    }
    }
    [HandleExceptions]
    public class YourClass {
    }
