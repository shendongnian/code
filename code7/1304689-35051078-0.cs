    int page;
                bool pagePresent = int.TryParse(model.Page, out page);
    
                string firstName = string.Empty;
                bool firstNamePresent = (string.IsNullOrEmpty(model.FirstName));
    
                var query = (from a in this.Context.Applicants
                             where (pagePresent || a.PageNum == page)
                             && (firstNamePresent || a.FirstName == firstName)
                             select new
                             {
                                 a.PageNum,
                                 a.FirstName,
                                 a.LastName
                             });
