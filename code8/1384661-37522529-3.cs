    SqlCommand command1 = new SqlCommand();
    command1.Parameters.Add("@PersonalIdentityNumber", SqlDbType.NVarChar);
    ... add other parameters with the exact datatype here
    foreach (Person p in myPersons)
    {
        SqlCommand command1 = new SqlCommand();
        try
        {
            // Pass the command created above, not recreate another one...
            Avreg(command1, p.UnregistrationReason, 
                            p.GivenNameNumber, p.ProtectedIdentity, 
                            p.CitizenshipDate, p.NationalRegistrationDate);
            command1.Parameters["@PersonalIdentityNumber"].Value = string.Format("{0}{1}", p.PersonalIdentityNumber, p.SpecialIdentityNumber));
            .... set the values for the other parameters .....
            command1.ExecuteNonQuery();
        }
        catch(.....)
        ...
    }
