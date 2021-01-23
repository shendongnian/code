    public int InsertUserData(UserDetail userDetail, BusinessObjects objects,PersonalData newPersonal,EducationalData newEducational,ContactData newContact)
        {
            try
            {
                UserCredential objCredentials;
                int result=1;
                if (objects.Status==1)
                {
                     objCredentials = newPersonEntity.UserCredentials
                                                     .First(cd => cd.UserName == objects.UserName);
                    objCredentials.Status = objects.Status;
                    newPersonEntity.UserDetails.Add(userDetail);
                     result = newPersonEntity.SaveChanges();
                    return result;
                }
                else if (objects.Status == 2)
                {
                    switch (objects.FormId)
                    {
                        case 1:
                                 objCredentials = newPersonEntity.UserCredentials
                                                 .First(cd => cd.UserName == objects.UserName);
                                objCredentials.Status = objects.Status;
                                newPersonEntity.PersonalDatas.Add(newPersonal);
                                result = newPersonEntity.SaveChanges();
                                break;
                        case 2:
                                 objCredentials = newPersonEntity.UserCredentials
                                                 .First(cd => cd.UserName == objects.UserName);
                                objCredentials.Status = objects.Status;
                                newPersonEntity.EducationalDatas.Add(newEducational);
                                result = newPersonEntity.SaveChanges();
                                break;
                        case 3: 
                                 objCredentials = newPersonEntity.UserCredentials
                                                 .First(cd => cd.UserName == objects.UserName);
                                objCredentials.Status = objects.Status;
                                newPersonEntity.ContactDatas.Add(newContact);
                                result = newPersonEntity.SaveChanges();
                                break;
    
                       default:
                                break;
                    }
    
                   return result;
                }
                else
                {
                  return 0; // or any other value
                }
    
            }
            catch (Exception ex)
            {  
                CatchError(ex);
                return 3;
            }
    
    
        }
