    public static DateTime[] GetHolidays(int year)
    {
        List<DateTime> result = new List<DateTime>();
        result.Add(new DateTime(year, 1, 1)); //New Year Day
        result.Add(new DateTime(year, 4, 25)); //Dia da Liberdade (PT)
        result.Add(new DateTime(year, 5, 1)); //Labour Day
        result.Add(new DateTime(year, 6, 10)); //Dia de Portugal (PT)
        result.Add(new DateTime(year, 8, 15)); //Assumption of Mary
        result.Add(new DateTime(year, 10, 5)); //Implantação da república (PT)
        result.Add(new DateTime(year, 11, 1)); //All Saints' Day
        result.Add(new DateTime(year, 12, 1)); //Restauração da independência (PT)
        result.Add(new DateTime(year, 12, 8)); //Imaculada Conceição (PT?)
        result.Add(new DateTime(year, 12, 25)); //Christmas
        foreach (DateTime holiday in variable)
        {
            if (!result.Contains(holiday)) //if the holiday already exists then don't add
            {
                result.Add(holiday);
            }
        }
        return result.ToArray<DateTime>();
    }
