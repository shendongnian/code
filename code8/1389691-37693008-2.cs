	public static IObservable<Message> MyAnswer(IObservable<byte> source)
	{
		return source.Publish(s =>
			{
				return 
					Observable.Defer(()=>
						//Start consuming once we see a BOM
						s.SkipWhile(b => b != Message.BOM)
						 .Scan(new Accumulator(), (acc, cur)=>acc.Accumulate(cur))
					)
					.TakeWhile(acc=>!acc.IsEndOfMessage())
					.Where(acc=>!acc.IsBeginingOfMessage())
					.Select(acc=>acc.Value())
					.ToArray()
					.Where(buffer=>buffer.Any())
					.Select(buffer => Message.Create(buffer))
					.Repeat();
			});	
			
	}
	public class Accumulator
	{
		private int _index = 0;
		private byte _current =0;
		private bool _isCurrentEscaped = false;
		private bool _isNextEscaped = false;
		public Accumulator Accumulate(byte b)
		{
			_index++;
			_current = b;
			_isCurrentEscaped = _isNextEscaped;
			_isNextEscaped = (!IsHeader() && !_isCurrentEscaped && b==Message.Control);
			return this;
		}
		public byte Value()
		{
			return _current;
		}
		
		private bool IsHeader()
		{
			return _index < 5;
		}
		public bool IsBeginingOfMessage()
		{
			return _index == 1 && _current == Message.BOM;
		}
		public bool IsEndOfMessage()
		{
			return !IsHeader()
				&& _current == Message.EOM 
				&& !_isCurrentEscaped;
		}
	}
