                var patient = da.Patients.ToList().Find(x => x.PatientId == patientid);
                Consultation _consultation = new Consultation
                {
                  ConsultId = cv.ConsultId,
                  ConsultDate = date,
                  ConsultTime = time,
                  illness = cv.illness,
                  PresribedMed = cv.PresribedMed,
                  Symptoms = cv.Symptoms,
                  U_Id = patient.PatientId,
                };
                deprepo.Insert(_consultation);
            }
        }
    }
