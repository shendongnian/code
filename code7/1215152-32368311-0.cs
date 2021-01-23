                Expression<Func<Contact, bool>> cntExpression = p => p.LastName.ToLower().Trim().Contains(searchedText) ||
                    p.FirstName.ToLower().Trim().Contains(searchedText) ||
                    p.MiddleName.ToLower().Trim().Contains(searchedText) ||
                    p.NickName.ToLower().Trim().Contains(searchedText) ||
                    p.DriversLicenseNumber.ToLower().Trim().Contains(searchedText) ||
                    (p.FirstName + " " + p.LastName).ToLower().Trim().Contains(searchedText);
                var searchDate = default(DateTime);
                if (DateTime.TryParse(searchedText.Trim(), out searchDate))
                    cntExpression = cntExpression.And(p => p.DOB.HasValue && p.DOB == searchDate);
