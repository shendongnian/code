    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    public class Program
    {
    	public static string SHARED_KEY = "";
    	public static string ACCOUNT = "bigfont";
    	public static void Main()
    	{
    		var dateHeader = GetDateHeader();
    		var versionHeader = GetVersionHeader();
    		var signature = GetSignature(dateHeader, versionHeader);
    		var encodedSignature = GetEncodedSignature(signature);
    		var authorizationHeader = GetAuthorizationHeader(ACCOUNT, encodedSignature);
    		Console.WriteLine("\n---Request Headers---\n");
    		Console.WriteLine(dateHeader);
    		Console.WriteLine(versionHeader);
    		Console.WriteLine(authorizationHeader);
    		Console.WriteLine("\n---String to Sign---\n");
    		Console.WriteLine("'" + signature + "'");	
    	}
    
    	public static string GetDateHeader()
    	{
    		var date = DateTime.Now.ToString("R", System.Globalization.CultureInfo.InvariantCulture);
    		var dateHeader = "x-ms-date:" + date;
    		return dateHeader;
    	}
    
    	public static string GetVersionHeader()
    	{
    		var versionHeader = "x-ms-version:2009-09-19";
    		return versionHeader;
    	}
    
    	public static string GetSignature(string dateHeader, string versionHeader)
    	{
    		var VERB = "GET";
    		var ContentEncoding = "";
    		var ContentLanguage = "";
    		var ContentLength = "";
    		var ContentMD5 = "";
    		var ContentType = "";
    		var Date = "";
    		var IfModifiedSince = "";
    		var IfMatch = "";
    		var IfNoneMatch = "";
    		var IfUnmodifiedSince = "";
    		var Range = "";
    		var CanonicalizedHeaders = dateHeader + "\n" + versionHeader + "\n";
    		var CanonicalizedResource = "/bigfont/\ncomp:list";
    		var builder = new StringBuilder();
    		builder.Append(VERB + "\n");
    		builder.Append(ContentEncoding + "\n");
    		builder.Append(ContentLanguage + "\n");
    		builder.Append(ContentLength + "\n");
    		builder.Append(ContentMD5 + "\n");
    		builder.Append(ContentType + "\n");
    		builder.Append(Date + "\n");
    		builder.Append(IfModifiedSince + "\n");
    		builder.Append(IfMatch + "\n");
    		builder.Append(IfNoneMatch + "\n");
    		builder.Append(IfUnmodifiedSince + "\n");
    		builder.Append(Range + "\n");
    		builder.Append(CanonicalizedHeaders);
    		builder.Append(CanonicalizedResource);
    		return builder.ToString();
    	}
    
    	public static string GetEncodedSignature(string stringToSign)
    	{
    		var hmac = new HMACSHA256(Encoding.UTF8.GetBytes(SHARED_KEY));
    		var bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(stringToSign));
    		var signature = Convert.ToBase64String(bytes);
    		return signature;
    	}
    
    	public static string GetAuthorizationHeader(string account, string signedSignature)
    	{
    		return string.Format("Authorization: SharedKey {0}:{1}", account, signedSignature);
    	}
    }
