	public static string RemoveHtmlTags(string html)
    {
		string htmlRemoved = Regex.Replace(html, @"<script[^>]*>[\s\S]*?</script>|<[^>]+>|&nbsp;", " ").Trim();
		string normalised = Regex.Replace(htmlRemoved, @"\s{2,}", " ");
		return normalised;
    }
    //remove html elements
	html = RemoveHtmlTags(html);
