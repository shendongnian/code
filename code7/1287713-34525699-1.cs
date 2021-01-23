	var htmlStr = "\\x26lt;span\\x26gt; \\x26lt;/span\\x26gt;";
    // Take out the extra stars
	var result = Regex.Replace(htmlStr, @"\*\*([^*]*)\*\*", "$1");   
	// Unescape \x values
	result = Regex.Replace(htmlStr,
					@"\\x([a-fA-F0-9]{2})", 
					match => char.ConvertFromUtf32(
						Int32.Parse(match.Groups[1].Value, 
						System.Globalization.NumberStyles.HexNumber)));
	// Decode html entities
	htmlStr = WebUtility.HtmlDecode(result);
