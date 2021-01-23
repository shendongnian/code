    value = string.Empty;
    if (cell.StyleIndex != null)
    {
        DateTime res;
        if (DateTime.TryParse(cell.CellValue.Text, out res))
        {
            value = res.ToString("yyyy-MM-dd");
        }
    }
