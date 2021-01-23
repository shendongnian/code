      if (pageIndex <= 0)
                pageIndex = 1;
            pageIndex = ((pageIndex - 1) * pageSize) ;
            var patient = _patientRepository.Table.Join(_DoctorPatient.Table.Where(x => x.DoctorId == Id && x.IsBlocked==false), x => x.Id, d => d.PatientId, (x, d) => new { x = x });
            if (state != "")
                patient = patient.Where(x => x.x.State.Contains(state));
            if (name != "")
                patient = patient.Where(x => (x.x.FirstName + x.x.LastName).Contains(name));
            if (sdate != null)
                patient = patient.Where(x => x.x.CreatedDate >= sdate);
            if (eDate != null)
                patient = patient.Where(x => x.x.CreatedDate <= eDate);
            var result = patient.Select(x => x.x).Select(x => new PatientDoctorVM() { PatientId = x.Id, Id = x.Id, FirstName = x.FirstName, LastName = x.LastName, SSN = x.NewSSNNo, UserProfileId = x.UserProfileId, Email = x.Email, TumbImagePath = x.TumbImagePath }).OrderBy(x => x.Id).Skip(pageIndex).Take(pageSize).ToList();
   
