    /// <summary>
    /// Specifies language style to represent an Hexadecimal value
    /// </summary>
    public enum HexadecimalStyle : int
    {
    
    	/// <summary>
    	/// C# Hexadecimal syntax.
    	/// </summary>
    	CSharp = 0,
    
    	/// <summary>
    	/// Visual Basic.Net Hexadecimal syntax.
    	/// </summary>
    	VbNet = 1
    
    }
    
    
    /// ----------------------------------------------------------------------------------------------------
    /// <summary>
    /// Converts an Hexadecimal value to its corresponding representation in the specified language syntax.
    /// </summary>
    /// ----------------------------------------------------------------------------------------------------
    /// <example> This is a code example.
    /// <code>
    /// Dim value As String = HexadecimalConvert(HexadecimalStyle.CSharp, "48 65 6C 6C 6F 20 57")
    /// Dim value As String = HexadecimalConvert(HexadecimalStyle.VbNet, "48 65 6C 6C 6F 20 57")
    /// </code>
    /// </example>
    /// ----------------------------------------------------------------------------------------------------
    /// <param name="style">
    /// The <see cref="CryptoUtil.HexadecimalStyle"/> to represent the Hexadecimal value.
    /// </param>
    /// 
    /// <param name="value">
    /// The Hexadecimal value.
    /// </param>
    /// 
    /// <param name="separator">
    /// The string used to separate Hexadecimal sequences.
    /// </param>
    /// ----------------------------------------------------------------------------------------------------
    /// <returns>
    /// The resulting value.
    /// </returns>
    /// ----------------------------------------------------------------------------------------------------
    /// <exception cref="InvalidEnumArgumentException">
    /// style
    /// </exception>
    /// ----------------------------------------------------------------------------------------------------
    [DebuggerStepThrough()]
    public string HexadecimalConvert(HexadecimalStyle style, string value, string separator = "")
    {
    
    	string styleFormat = "";
    
    	switch (style) {
    
    		case CryptoUtil.HexadecimalStyle.CSharp:
    			styleFormat = "0x{0}";
    
    			break;
    		case CryptoUtil.HexadecimalStyle.VbNet:
    			styleFormat = "&H{0}";
    
    			break;
    		default:
    
    			throw new InvalidEnumArgumentException(argumentName: "style", invalidValue: style, enumClass: typeof(HexadecimalStyle));
    	}
    
    	if (!string.IsNullOrEmpty(separator)) {
    		value = value.Replace(separator, "");
    	}
    
    
    	if ((value.StartsWith("0x", StringComparison.OrdinalIgnoreCase)) || (value.StartsWith("&H", StringComparison.OrdinalIgnoreCase))) {
    		value = value.Substring(2);
    
    	}
    
    	return string.Format(styleFormat, Convert.ToString(value).ToUpper);
    
    }
