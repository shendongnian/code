    IEnumerable<object> ToJson(IEnumerable<LolCat> lolCats, string id)
    {
        try
        {
            foreach (var lolCat in lolCats)
                yield return new { name = lolCat.name };
        }
        catch (Exception ex)
        {
            throw new Exception(id, ex); // use a more appropriate exception
        }
    }
