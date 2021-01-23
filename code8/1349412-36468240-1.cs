    List<StudentList> Student = new List<StudentList>();
    
                if (AcademicId != null && CompanyId != null && CompanyLocationId != null && ClassId == null && SectionId == null) //&& )//&& ClassId != null) //)
                {
                    Student = (from a in db.Student_Re_Admission
                               join b in db.Student_Registration on a.Registration_Id equals b.Registration_Id
                               join c in db.Student_Roll_No_Assign on a.Registration_Id equals c.Registration_Id                           
    
                               where c.Academic_Year_Id == AcademicId && c.Company_ID == CompanyId && c.COMPANY_LOCATION_ID == CompanyLocationId
                               && a.Academic_Year_Id == AcademicId && c.Class_Id == ClassId && a.Class_Id == ClassId
                               && a.Section_Id == SectionId && c.Section_Id == SectionId
                               //&& a.Registration_Id != RegId.Contains(a.Registration_Id)
                               && a.Promoted == false && a.Delete_Flag == false
                               //a.Academic_Year_Id == AcademicId && a.Company_ID == CompanyId && a.COMPANY_LOCATION_ID == CompanyLocationId
    
                               select new StudentList()
                               {
                                   Registration_Id = a.Registration_Id,
                                   Admission_No = a.Admission_No,
                                   Student_First_Name = a.Student_First_Name,
                                   Student_Middle_Name = a.Student_Middle_Name,
                                   Student_Last_Name = a.Student_Last_Name,
                                   Set_Roll_No = c.Set_Roll_No,
                                   Roll_Id = c.Roll_Id
    
                               }).OrderBy(a => a.Registration_Id).ToList();
    }
