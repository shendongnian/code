    internal static string ConvertDuckbillSummaryListToHtml(List<PlatypusSummary> _PlatypusSummaryList)
    {
        StringBuilder builder = new StringBuilder();
        // Add the html opening tags and "preamble"
        builder.Append("<html>");
        builder.Append("<head>");
        builder.Append("<title>");
        builder.Append("bla"); // TODO: Replace "bla" with something less blah
        builder.Append("</title>");
        builder.Append("</head>");
        builder.Append("<body>");
        builder.Append("<table border='1px' cellpadding='5' cellspacing='0' ");
        builder.Append("style='border: solid 1px Silver; font-size: x-small;'>");
    
        // Add the column names row
        builder.Append("<tr align='left' valign='top'>");
        PropertyInfo[] properties = typeof(PlatypusSummary).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            builder.Append("<td align='left' valign='top'><b>");
            builder.Append(property.Name);
            builder.Append("</b></td>");
        }
        builder.Append("</tr>");
    
        // Add the data rows
        foreach (PlatypusSummary ps in _PlatypusSummaryList)
        {
            builder.Append("<tr align='left' valign='top'>");
    
            builder.Append("<td align='left' valign='top'>");
            builder.Append(ps.PlatypusName);
            builder.Append("</td>");
    
            builder.Append("<td align='left' valign='top'>");
            builder.Append(ps.TotalOccurrencesOfSummaryItems);
            builder.Append("</td>");
    
            builder.Append("<td align='left' valign='top'>");
            builder.Append(ps.TotalSummaryExceptions);
            builder.Append("</td>");
    
            builder.Append("<td align='left' valign='top'>");
            builder.Append(ps.TotalPercentageOfSummaryExceptions);
            builder.Append("</td>");
            
            builder.Append("</tr>");
        }
    
        // Add the html closing tags
        builder.Append("</table>");
        builder.Append("</body>");
        builder.Append("</html>");
    
        return builder.ToString();
    }
