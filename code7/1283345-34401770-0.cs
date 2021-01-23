    public class LinkerThingBob
    {
      private readonly TaskCompletionSource<object> _tcs = new TaskCompletionSource<object>();
      private async Task ObserveAsync(Task task)
      {
        try
        {
          await task;
          _tcs.TrySetResult(null);
        }
        catch (Exception ex)
        {
          _tcs.TrySetException(ex);
        }
      }
      public void LinkTo<T>(BufferBlock<T> messages) where T : class
      {
        var action = new ActionBlock<IMsg>(_ => this.Tx(messages, _));
        var _ = ObserveAsync(action.Completion);
        this._inboundMessageBuffer.LinkTo(block);
      }
      public Task Completion { get { return _tcs.Task; } }
    }
