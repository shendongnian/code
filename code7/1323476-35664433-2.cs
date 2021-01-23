	static string Base64UrlEncode (MimeMessage message)
	{
		using (var stream = new MemoryStream ()) {
			using (var filtered = new FilteredStream (stream)) {
				filtered.Add (EncoderFilter.Create (ContentEncoding.Base64));
				filtered.Add (new UrlEncodeFilter ());
				message.WriteTo (filtered);
				filtered.Flush ();
			}
			return Encoding.ASCII.GetString (stream.GetBuffer (), 0, (int) stream.Length);
		}
	}
