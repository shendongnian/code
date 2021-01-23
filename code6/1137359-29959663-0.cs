         if(_dbContext.tblProfile.Any())
            {
     //Verify records in tblProfile table, if there's any record exist or not
                        Decimal topID = 0;
                        var profileID = _dbContext.tblProfile.Max(n => n.profileid);
                        try
                        {
                            if (profileID == null)
                            {
                                topID = 1;
                            }
                            else
                            {
                                topID = Convert.ToDecimal(profileID);
                                topID++;
                            }
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        return topID;
            }
            else
            { //If there's no value in table then assuming it should return 1.
                return 1;
            }
