        public ActionResult EditEmergencyContact (List<EmergencyContact> _emergencyContactModel)
                {
    
                    try
                    {
    
                        if (_emergencyContactModel != null && _emergencyContactModel.Count() > 0)
    
                        {
                            if (ModelState.IsValid)
                            {
                                bool validation = true;
    
                                for (int i = 1; i < _emergencyContactModel.Count(); i++)
                                {
    
                                    if (_emergencyContactModel[i].EmergencyContactID != null)
                                    {
    
                                        int _entityID = _studentProfileServices.EditEmergencyContactByStudentID(
    
                                        new EmergencyContact
                                        {
                                            EmergencyContactID = _emergencyContactModel[i].EmergencyContactID,
                                            StudentID = _emergencyContactModel[i].StudentID,
                                            NameOfContact = _emergencyContactModel[i].NameOfContact,
                                            Relationship = _emergencyContactModel[i].Relationship,
                                            Telephone = _emergencyContactModel[i].Telephone,
                                            Mobile = _emergencyContactModel[i].Mobile,
                                            Address = _emergencyContactModel[i].Address
                                        });
        
                                        if (_entityID == 0)
                                        {
                                            validation = false;
                                            break;
                                        }
                                    }
                                }
        
                                if (validation)
                                {
                                    return Json(new { Response = "Success" });
                                }
                                else
                                {
                                    return Json(new { Response = "Error" });
                                }
                            }
                            else
                            {
                                return Json(new { Response = "Invalid Entry" });
                            }
                        }
                        else
                        {
                            return Json(new { Response = "Error! In Updating Record" });
                        }
                    }
                    catch (DataException ex)
                    {
                        ModelState.AddModelError("", "Unable To Edit Emergency Contact" + ex);
                    }
        
                    return RedirectToAction("MyProfile", "StudentProfile");
                }
