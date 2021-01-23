    Expression<Func<Contact, bool>> cntExpression;
    
    var searchDate = default(DateTime);
    if (DateTime.TryParse(searchText.Trim(), out searchDate)) 
    {
        cntExpression = p => p.DOB.HasValue && p.DOB == searchDate;
    } 
    else 
    {
        cntExpression = p => p.LastName.ToLower().Trim().Contains(searchedText) ||
                p.FirstName.ToLower().Trim().Contains(searchedText) ||
                p.MiddleName.ToLower().Trim().Contains(searchedText) ||
                p.NickName.ToLower().Trim().Contains(searchedText);
    }
