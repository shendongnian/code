    public static void ConvertToSwf(string pdfPath, string swfPath, int page)
	{
		try
		{
			string exe =  HttpContext.Current.Server.MapPath("PDF2SWF/pdf2swf.exe");
			if (!File.Exists(exe))
			{
				throw new ApplicationException("Can not find: " + exe);
			}
			
			StringBuilder sb = new StringBuilder();
			sb.Append(" -o \"" + swfPath + "\"");//output
			sb.Append(" -z");
			sb.Append(" -s flashversion=9");//flash version
			sb.Append(" -s disablelinks");
			sb.Append(" -p " + "1" + "-" + page);//page range
			sb.Append(" -j 100");//Set quality of embedded jpeg pictures to quality. 0 is worst (small), 100 is best (big). (default:85)
			sb.Append(" \"" + pdfPath + "\"");//input
			System.Diagnostics.Process proc = new System.Diagnostics.Process();
			proc.StartInfo.FileName = exe;
			proc.StartInfo.Arguments = sb.ToString();
			proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
			proc.Start();
			proc.WaitForExit();
			proc.Close();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
	public static int GetPageCount(string pdfPath)
	{
		try
		{
			byte[] buffer = File.ReadAllBytes(pdfPath);
			int length = buffer.Length;
			if (buffer == null)
				return -1;
			if (buffer.Length <= 0)
				return -1;
			string pdfText = Encoding.Default.GetString(buffer);
			System.Text.RegularExpressions.Regex rx1 = new System.Text.RegularExpressions.Regex(@"/Type\s*/Page[^s]");
			System.Text.RegularExpressions.MatchCollection matches = rx1.Matches(pdfText);
			return matches.Count;
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
			
