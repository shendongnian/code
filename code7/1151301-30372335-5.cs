	class MyStream : Stream
	{
		public override async Task<int> ReadAsync
          (byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			const string str = "Hi there!\r\n";
			await Task.Delay(1000);
			return Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, offset);
		}
		public override IAsyncResult BeginRead
          (byte[] buffer, int offset, int count, AsyncCallback callback, object state)
		{
			return ReadAsync(buffer, offset, count).ContinueWith(t => callback(t));
		}
		public override int EndRead(IAsyncResult asyncResult)
		{
            // Stolen from Stephen. Nicer than rethrowing the inner exception manually :)
            return ((Task<int>)asyncResult).GetAwaiter().GetResult();
		}
    }
