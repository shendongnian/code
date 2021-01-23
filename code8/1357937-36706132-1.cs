                foreach (Person p in myPersons)
                {
                    command1.Parameters.Clear();
                    command1.Parameters.AddWithValue("@PersonalIdentityNumber", string.Format("{0}{1}", p.PersonalIdentityNumber, p.SpecialIdentityNumber));
                    command1.Parameters.AddWithValue("@FirstName", p.FirstName);
                    command1.Parameters.AddWithValue("@LastName", p.LastName);
                    command1.Parameters.AddWithValue("@NationalRegistrationCountyCode", p.NationalRegistrationCountyCode);
                    command1.Parameters.AddWithValue("@NationalRegistrationMunicipalityCode", p.NationalRegistrationMunicipalityCode);
                    command1.Parameters.AddWithValue("@NationalRegistrationDistributionAddress2", p.NationalRegistrationDistributionAddress2 ?? DBNull.Value.ToString());
                    command1.Parameters.AddWithValue("@NationalRegistrationPostCode", p.NationalRegistrationPostCode ?? DBNull.Value.ToString());
                    ////command1.Parameters.AddWithValue("@NationalRegistrationCity", postOrt);
                    ////command1.Parameters.AddWithValue("@BirthCountyCode", fodelselanKod);
                    ////command1.Parameters.AddWithValue("@BirthParish", fodelseforsamling);
                    command1.Parameters.AddWithValue("@CitizenshipCode", p.CitizenshipCode);
                    //// command1.Parameters.AddWithValue("@CitizenshipDate", medborgarskapsdatum);
                    command1.Parameters.AddWithValue("@LastChangedDate", datum);
                    command1.ExecuteNonQuery();
                    Console.WriteLine(p.PersonalIdentityNumber);
                }
