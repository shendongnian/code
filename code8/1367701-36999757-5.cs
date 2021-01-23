    StringBuilder exceptionMessage = new StringBuilder();
    Exception inner = ex.InnerException;
    while (inner != null)
    {
        exceptionMessage.Append(inner.Message)
                        .Append(Environment.NewLine);
        inner = inner.InnerException;
    }
