    public decimal UrduNumberToEnglishNumber(string urduNumber)
    {
        var output = urduNumber.Replace("٠", "0").Replace( "١", "1").Replace("٢", "2").Replace( "٢", "2")
         .Replace("٣", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("٧", "7").Replace("٨", "8").Replace("٩", "9");
        var result = Convert.ToDecimal(output);
        return result;
    }
