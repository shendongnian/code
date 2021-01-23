	public static class Alphabet
	{
		private static readonly AsciiNumber Number1 = new AsciiNumber('1', new[]{
			new []{'|'},
			new []{'|'},
			new []{'|'},
			new []{'|'},
		});
		private static readonly AsciiNumber Number3 = new AsciiNumber('3', new[]{
			new []{'-','-','-'},
			new []{' ',' ','/'},
			new []{' ',' ','\\'},
			new []{'-','-','-'},
		});
		public static readonly IEnumerable<AsciiNumber> All = new[] { Number1, Number3 };
	}
