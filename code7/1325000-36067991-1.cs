    string TheSearchParameter = "John Smith";
    TheSearchParameter = TheSearchParameter.ToLower(); //case insensitive
    string[] pars = TheSearchParameter.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries); //to get all the pars
    var TheQuery = (from c in MyDC.Contacts
                    let l = new List<string>() {c.FirstName.ToLower(), c.LastName.ToLower()}
                    where l.Except(pars).Count() <= l.Count - pars.Length
                    select c.ColumnID).Distinct().ToList();
