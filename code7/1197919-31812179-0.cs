	public class CleanTextReader : StreamReader
	{
		private readonly ILog _logger;
		public CleanTextReader(Stream stream, ILog logger) : base(stream)
		{
			this._logger = logger;
		}
		public CleanTextReader(Stream stream) : this(stream, LogManager.GetLogger<CleanTextReader>())
		{
			//nothing to do here.
		}
		/// <summary>
		///     Reads a specified maximum of characters from the current stream into a buffer, beginning at the specified index.
		/// </summary>
		/// <returns>
		///     The number of characters that have been read, or 0 if at the end of the stream and no data was read. The number
		///     will be less than or equal to the <paramref name="count" /> parameter, depending on whether the data is available
		///     within the stream.
		/// </returns>
		/// <param name="buffer">
		///     When this method returns, contains the specified character array with the values between
		///     <paramref name="index" /> and (<paramref name="index + count - 1" />) replaced by the characters read from the
		///     current source.
		/// </param>
		/// <param name="index">The index of <paramref name="buffer" /> at which to begin writing. </param>
		/// <param name="count">The maximum number of characters to read. </param>
		/// <exception cref="T:System.ArgumentException">
		///     The buffer length minus <paramref name="index" /> is less than
		///     <paramref name="count" />.
		/// </exception>
		/// <exception cref="T:System.ArgumentNullException"><paramref name="buffer" /> is null. </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///     <paramref name="index" /> or <paramref name="count" /> is
		///     negative.
		/// </exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs, such as the stream is closed. </exception>
		public override int Read(char[] buffer, int index, int count)
		{
			try
			{
				var rVal = base.Read(buffer, index, count);
				var filteredBuffer = buffer.Select(x => XmlConvert.IsXmlChar(x) ? x : ' ').ToArray();
				Buffer.BlockCopy(filteredBuffer, 0, buffer, 0, count);
				return rVal;
			}
			catch (Exception ex)
			{
				this._logger.Error("Read(char[], int, int)", ex);
				throw;
			}
		}
		/// <summary>
		///     Reads a maximum of <paramref name="count" /> characters from the current stream, and writes the data to
		///     <paramref name="buffer" />, beginning at <paramref name="index" />.
		/// </summary>
		/// <returns>
		///     The position of the underlying stream is advanced by the number of characters that were read into
		///     <paramref name="buffer" />.The number of characters that have been read. The number will be less than or equal to
		///     <paramref name="count" />, depending on whether all input characters have been read.
		/// </returns>
		/// <param name="buffer">
		///     When this method returns, this parameter contains the specified character array with the values
		///     between <paramref name="index" /> and (<paramref name="index" /> + <paramref name="count" /> -1) replaced by the
		///     characters read from the current source.
		/// </param>
		/// <param name="index">The position in <paramref name="buffer" /> at which to begin writing.</param>
		/// <param name="count">The maximum number of characters to read. </param>
		/// <exception cref="T:System.ArgumentNullException"><paramref name="buffer" /> is null. </exception>
		/// <exception cref="T:System.ArgumentException">
		///     The buffer length minus <paramref name="index" /> is less than
		///     <paramref name="count" />.
		/// </exception>
		/// <exception cref="T:System.ArgumentOutOfRangeException">
		///     <paramref name="index" /> or <paramref name="count" /> is
		///     negative.
		/// </exception>
		/// <exception cref="T:System.ObjectDisposedException">The <see cref="T:System.IO.TextReader" /> is closed. </exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
		public override int ReadBlock(char[] buffer, int index, int count)
		{
			try
			{
				var rVal = base.ReadBlock(buffer, index, count);
				var filteredBuffer = buffer.Select(x => XmlConvert.IsXmlChar(x) ? x : ' ').ToArray();
				Buffer.BlockCopy(filteredBuffer, 0, buffer, 0, count);
				return rVal;
			}
			catch (Exception ex)
			{
				this._logger.Error("ReadBlock(char[], in, int)", ex);
				throw;
			}
		}
		/// <summary>
		///     Reads the stream from the current position to the end of the stream.
		/// </summary>
		/// <returns>
		///     The rest of the stream as a string, from the current position to the end. If the current position is at the end of
		///     the stream, returns an empty string ("").
		/// </returns>
		/// <exception cref="T:System.OutOfMemoryException">
		///     There is insufficient memory to allocate a buffer for the returned
		///     string.
		/// </exception>
		/// <exception cref="T:System.IO.IOException">An I/O error occurs. </exception>
		public override string ReadToEnd()
		{
			var chars = new char[4096];
			int len;
			var sb = new StringBuilder(4096);
			while ((len = Read(chars, 0, chars.Length)) != 0)
			{
				sb.Append(chars, 0, len);
			}
			return sb.ToString();
		}
	}
