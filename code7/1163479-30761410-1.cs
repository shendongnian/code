            public void CreateGRCMember(string firstName, string lastName, string address1, string address2, string city, string county, string postcode, string telephone, DateTime dateOfBirth, string dietary, string compLicenceNo , int? LicenceTypeId,  string nOKFirstName, string nOKLastName, string nOKTelephone, int? relationshipTypeId, bool otherOrgsGRC, bool otherClubEvents, bool otherOrgsOutside,  string userId)
        {
            var GRCMember = new GRCMember { FirstName = firstName, LastName = lastName, Address1 = address1, Address2 = address2, City = city, County = county, Postcode = postcode, Telephone = telephone, DateOfBirth = dateOfBirth, Dietary = dietary, CompLicenceNo = compLicenceNo, LicenceTypeId = LicenceTypeId, NOKFirstName = nOKFirstName, NOKLastName = nOKLastName, NOKTelephone= nOKTelephone, RelationshipTypeId = relationshipTypeId, OtherOrgsGRC = otherOrgsGRC, OtherClubEvents = otherClubEvents, OtherOrgsOutside = otherOrgsOutside,  ApplicationUserId = userId };
            db.GRCMember.Add(GRCMember);
            db.SaveChanges();
        }
