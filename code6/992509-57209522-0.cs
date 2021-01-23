public static bool SendAsyncSuppressFlow(this Socket self, SocketAsyncEventArgs e)
{
    var control = ExecutionContext.SuppressFlow();
    try
    {
        return self.SendAsync(e);
    }
    finally
    {
        control.Undo();
    }
}
public static bool ReceiveAsyncSuppressFlow(this Socket self, SocketAsyncEventArgs e)
{
    var control = ExecutionContext.SuppressFlow();
    try
    {
        return self.ReceiveAsync(e);
    }
    finally
    {
        control.Undo();
    }
}
I created these extension methods to make this a bit simpler and more explicit.
Traces with dotMemory showed that memory allocations really do go down to zero.
