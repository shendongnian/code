    public bool SaveInformation(Other_Admission otherAdmission, Account_Bill aBill)
    {
    using (var transaction = _aRepository.BeginTransaction())  
    {  
        try  
        {
          _aRepository.OtherAdmission.Insert(otherAdmission);  //Assume this is Admission edmx
           aBill.StudentRoll=otherAdmission.StudentRoll;
          _aBillRepository.Bill.Insert(aBill); //Assume this is Account edmx
         _aRepository.SaveChanges();
         _aBillRepository.SaveChanges();
        return true;
      }
    }
    catch (Exception ex)  
        {  
            transaction.Rollback();  
        } 
    }
