    /// <summary>
    ///     Creates a filename given the end date provided
    /// </summary>
    /// <param name="date">It is a date</param>
    /// <param name="filePath">Valid path</param>
    /// <returns></returns>
    public static string GetFileName(DateTime date, string filePath) {
       var ret = string.Format("file_{0}[{1}].txt", date.ToString("yyyyMMdd"), date.ToString("HHmm"));
    	return Path.Combine(filePath, ret);
    }
