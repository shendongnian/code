    int _entityID_0 = _studentProfileServices.EditEmergencyContactByStudentID(
    new EmergencyContact
    {
    	EmergencyContactID = _emergencyContactModel[0].EmergencyContactID,
    	StudentID = _emergencyContactModel[0].StudentID,
    	NameOfContact = _emergencyContactModel[0].NameOfContact,
    	Relationship = _emergencyContactModel[0].Relationship,
    	Telephone = _emergencyContactModel[0].Telephone,
    	Mobile = _emergencyContactModel[0].Mobile,
    	Address = _emergencyContactModel[0].Address
    });
    
    int _entityID_1 = _studentProfileServices.EditEmergencyContactByStudentID(
    new EmergencyContact
    {
    	EmergencyContactID = _emergencyContactModel[1].EmergencyContactID,
    	StudentID = _emergencyContactModel[1].StudentID,
    	NameOfContact = _emergencyContactModel[1].NameOfContact,
    	Relationship = _emergencyContactModel[1].Relationship,
    	Telephone = _emergencyContactModel[1].Telephone,
    	Mobile = _emergencyContactModel[1].Mobile,
    	Address = _emergencyContactModel[1].Address
    });
    
    if (_entityID_0 != 0 && _entityID_1 != 0)
    {
    	return Json(new { Response = "Success" });
    }
    else
    {
    	return Json(new { Response = "Error" });
    }
