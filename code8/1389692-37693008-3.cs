	public static IObservable<Message> CurrentAnswer(IObservable<byte> source)
	{
		return Observable.Create<Message>(o =>
		{
			// some crude parsing code for the sake of example
			bool nextIsEscaped = false;
			bool readingHeader = false;
			bool readingBody = false;
			List<byte> body = new List<byte>();
			List<byte> header = new List<byte>();
			return source.Subscribe(b =>
			{
				if (b == 0x81 && !nextIsEscaped && !readingHeader)
				{
					// start
					readingHeader = true;
					readingBody = false;
					nextIsEscaped = false;
				}
				else if (b == 0x82 && !nextIsEscaped && !readingHeader)
				{
					// end
					readingHeader = false;
					readingBody = false;
					if (header.Count > 0 || body.Count > 0)
					{
						o.OnNext(new Message()
						{
							Header = header.ToArray(),
							Data = body.ToArray()
						});
						header.Clear();
						body.Clear();
					}
					nextIsEscaped = false;
				}
				else if (b == 0x1B && !nextIsEscaped && !readingHeader)
				{
					nextIsEscaped = true;
				}
				else
				{
					if (readingHeader)
					{
						header.Add(b);
						if (header.Count == 3)
						{
							readingHeader = false;
							readingBody = true;
						}
					}
					else if (readingBody)
						body.Add(b);
					nextIsEscaped = false;
				}
	
			});
		});
	
	}
