	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using System.Diagnostics;
	using System.Web;
	using System.Web.Util;
	using System.Text;
	using System.IO;
	/// <summary>
	/// Summary description for CustomHttpEncoder
	/// </summary>
	public class CustomHttpEncoder : HttpEncoder
	{
		//
		// TODO: Add constructor logic here
		//
		public CustomHttpEncoder()
		{
		}
		protected override void HtmlEncode(string value, TextWriter output)
		{
			if (value != null) {
				MyHtmlEncode(value, output);
			}
		}
		protected override void HtmlAttributeEncode(string value, TextWriter output)
		{
			if (value != null) {
				MyHtmlEncode(value, output);
			}
		}
		private void MyHtmlEncode(string value, TextWriter output)
		{
			if (value != null) {
				string encodedValue = "";
				for (int i = 0; i <= value.Length - 1; i++) {
					byte[] asciiVal = Encoding.ASCII.GetBytes(value.Substring(i, 1));
					encodedValue += "&#" + asciiVal(0).ToString + ";";
				}
				output.Write(encodedValue);
			}
		}
	}
