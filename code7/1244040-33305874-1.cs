    public ContentResult Save(PatientViewModel patientViewModel)
            {
                Patient patient = new Patient();
    
                                  .
                                  .
                                  .
       
                string patVM = JsonConvert.SerializeObject(new { patientViewModel });
                return new ContentResult { Content = patVM, ContentType = "application/json" };
              
            }
