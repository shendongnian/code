	public class AsciiNumber
	{
		private readonly char[][] _data;
		public AsciiNumber(char character, char[][] data)
		{
			this._data = data;
			this.Character = character;
		}
		public char Character
		{
			get;
			private set;
		}
		public int Width
		{
			get
			{
				return this._data[0].Length;
			}
		}
		public int Height
		{
			get
			{
				return this._data.Length;
			}
		}
		public bool Match(string[] source, int startRow, int startColumn)
		{
			if (startRow + this.Height > source.Length)
			{
				return false;
			}
			for (var i = startRow; i < startRow + this.Height; i++)
			{ 
				var row = source[i];
				if (startColumn + this.Width > row.Length)
				{
					return false;
				}
				for (var j = startColumn; j < startColumn + this.Width; j++)
				{
					if (this._data[i - startRow][j - startColumn] != row[j])
					{
						return false;
					}
				}
			}
			return true;
		}
	}
 
