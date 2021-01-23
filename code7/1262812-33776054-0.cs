    private void dgvProducts_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {        
        if ((e.ColumnIndex == dgvProducts.Columns["colDescription"].Index) && e.Value != null)
        {
            DataGridViewCell cell = dgvProducts.Rows[e.RowIndex].Cells[e.ColumnIndex];
            cell.ToolTipText = String.Join(Environment.NewLine, e.Value.ToString().DivideLongString());
        }
    }
    //-------------- Extension Methods ------------- C# 6.0
     
    using static System.String;
    public static class Extensions
    {
        public static string[] DivideLongString(this string text, int length = 10)
        {
            if (text.Length <= length) return new[] { text };
            var words = text.GetTotalWords();
            var output = new string[(words.Length % length > 1 ? words.Length / length + 1 : words.Length % length < 1 ? words.Length / length - 1 : words.Length / length) + 100];
            var oIndex = 0;
            var wIndex = length - 1;
            try
            {
                for (var i = 0; i < words.Length; i++)
                {
                    if (wIndex < i)
                    {
                        wIndex += length - 1;
                        oIndex++;
                    }
                    output[oIndex] += $"{words[i]} ";
                }
                if (output.Length > 2 && !IsNullOrEmpty(output[output.Length - 1]) && output[output.Length - 1].CountWords() < 3)
                {
                    output[output.Length - 2] += output[output.Length - 1];
                    output[output.Length - 1] = Empty;
                }
                return output.Where(val => !IsNullOrEmpty(val)).ToArray();
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
                return output.Where(val => !IsNullOrEmpty(val)).ToArray();
            }
        }
        public static string ReplaceMultipleSpacesWith(this string text, string newString)
        {
            return Regex.Replace(text, @"\s+", newString);
        }
        public static string[] GetTotalWords(this string text)
        {
            text = text.Trim().ReplaceMultipleSpacesWith(" ");
            var words = text.Split(' ');
            return words;
        }
    }
