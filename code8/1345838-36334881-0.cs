    public void PrintTicketFromList<T>(List<T> lstArticles, short intCopies)
    {   
        foreach (var item in lstArticles)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                var value = prop.getValue(item);
            }
        }
    }
