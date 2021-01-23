    /// <summary>
    /// Remove all HTML special characters from datatable field if they are present 
    /// </summary>
    /// <param name="dt"></param>
    private static void RemoveHtmlSpecialChars(DataTable dt)
    {
        for (int rows = 0; rows < dt.Rows.Count; rows++)
        {
            for (int column = 0; column < dt.Columns.Count; column++)
            {
                dt.Rows[rows][column] = dt.Rows[rows][column].ToString().Replace("&nbsp;", string.Empty);
            }
        }
    }
