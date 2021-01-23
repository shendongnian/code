    private IEnumerable<PersonDto> Translate(IEnumerable<Person> persons)
    {
        if (persons == null) yield break;
    
        foreach (var p in persons)
        {
            yield return new PersonDto()
            {
                FirstName = p.FirstName,
                LastName = p.LastName,
                MiddleName = p.MiddleName
            }
        }
    }
