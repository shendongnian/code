    foreach (Person person in persons)
    {
      var finalValue = person.PersonDatas.First(x => x.FinalValue != null);
      sb.AppendLine(string.Format("\"{0}\",\"{1}\",\"{2}\"",
        person.ClientInternalPerson_ID,
        person.FirstName + " " + person.LastName,
        finalValue));
    }
