    bookingViewModel.PatientList = db.Patients.Select(p => new SelectListItem()
            {
                Value = p.PatientId.ToString(),
                Text = p.User.FirstName + " " + p.User.LastName
            });
