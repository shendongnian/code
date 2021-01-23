    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    public class Program
    {
    	public static void Main()
    	{
    		var dateHeader = GetDateHeader();
    		var versionHeader = GetVersionHeader();
    		var signature = GetSignatureString(dateHeader, versionHeader);
    		GetEncodedSignature(signature);
    	}
    	
    	public static string GetDateHeader()
    	{
    		var date = DateTime.UtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'");
    		var dateHeader = "x-ms-date:" + date;
    		
    		Console.WriteLine(dateHeader);
    		return dateHeader;
    	}
    	
    	public static string GetVersionHeader()
    	{
    		var versionHeader = "x-ms-version:2009-09-19";
    		Console.WriteLine(versionHeader);
    		return versionHeader;
    	}
    	
    	public static string GetSignatureString(string dateHeader, string versionHeader)
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
    		var CanonicalizedHeaders = dateHeader + "\n" + versionHeader;
    		var CanonicalizedResource = "/bigfont\ncomp:list";
    		
    		var signatureString = VERB + "\n" + ContentEncoding + "\n" + ContentLanguage + "\n" + ContentLength + "\n" + ContentMD5 + "\n" + ContentType + "\n" + Date + "\n" + IfModifiedSince + "\n" + IfMatch + "\n" + IfNoneMatch + "\n" + IfUnmodifiedSince + "\n" + Range + "\n" + CanonicalizedHeaders + CanonicalizedResource;		
    		// Console.WriteLine(signatureString);
    		return signatureString;
    	}
    	
    	public static string GetEncodedSignature(string signature)
    	{
    		var hmac = new HMACSHA256(Encoding.UTF8.GetBytes("SHAREDKEY"));
    		var bytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(signature));
    		var hash = Convert.ToBase64String(bytes);
    		Console.WriteLine(hash);
    		return hash;
    	}
    }
