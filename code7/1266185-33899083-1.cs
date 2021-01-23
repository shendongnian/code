    // CompressPath = 0x800000, // For an authority based Uri remove/compress /./ /../ in the path
    // UnEscapeDotsAndSlashes = 0x2000000, // additionally unescape dots and slashes before doing path compression
	/// <summary>
	/// http://referencesource.microsoft.com/#System/net/System/_UriSyntax.cs
	/// </summary>
	public static void LeaveDotsAndSlashesEscaped() {
		Uri uri = new Uri("ftp://myUrl/%2E%2E/%2E%2E/");
		if (uri == null) {
			throw new ArgumentNullException("uri");
		}
		FieldInfo fieldInfo = uri.GetType().GetField("m_Syntax", BindingFlags.Instance | BindingFlags.NonPublic);
		if (fieldInfo == null) {
			throw new MissingFieldException("'m_Syntax' field not found");
		}
		object uriParser = fieldInfo.GetValue(uri);
		fieldInfo = typeof(UriParser).GetField("m_Flags", BindingFlags.Instance | BindingFlags.NonPublic);
		if (fieldInfo == null) {
			throw new MissingFieldException("'m_Flags' field not found");
		}
		object uriSyntaxFlags = fieldInfo.GetValue(uriParser);
		// Clear the flags that we don't want
		uriSyntaxFlags = (int)uriSyntaxFlags & ~0x2000000 & ~0x800000;
		fieldInfo.SetValue(uriParser, uriSyntaxFlags);
	}
