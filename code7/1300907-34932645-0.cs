    foreach (Person person in persons)
    {
      var finalValues = person.PersonDatas.Where(x => x.FinalValue != null);
      foreach(var finalValue in finalValues)
      {
        sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\"",
          person.ClientInternalPerson_ID,
          person.FirstName + " " + person.LastName,
          finalValue));
      }
    }
