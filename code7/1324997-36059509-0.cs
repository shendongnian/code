            string[] parametersArray = null;
            int parametersCount = 0;
            if(!string.IsNullOrEmpty(TheSearchParameter))
            {
                parametersArray = TheSearchParameter.Split(new char[0],StringSplitOptions.RemoveEmptyEntries);
                parametersCount = parametersArray.Length;
            }
           
            var TheQuery = (from c in MyDC.Contacts
                            where (parametersCount == 0 || (parametersCount > 0 && (parametersArray.Contains(c.FirstName) ||
                                   parametersArray.Contains(c.LastName))))
                            select c.ColumnID).Distinct().ToList();
