    private void GetUnion(List<string> lst1, List<string> lst2)
    {
        List<string> lstUnion = new List<string>();
        foreach (string value in lst1)
        {
            string valueColumn1 = value.Split(';')[0];
            string valueColumn2 = value.Split(';')[1];
            string valueColumn3 = value.Split(';')[2];
            string result = lst2.FirstOrDefault(s => s.Contains(";" + valueColumn2 + ";" + valueColumn3));
            if (result != null)
            {
                if (!lstUnion.Contains(result))
                {
                    lstUnion.Add(result);
                }                   
            }
        }
    }
