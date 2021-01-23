    var viewModel = 
        db.Wards
            .Where(w => w.ID == id)
            .Select(w => new WardViewModel
                {
                    Name = w.WardTitle,
                    Beds = w.Beds
                        .Select(b => new
                            {
                                b.BedTitle,
                                InPatient = b.Inpatients.FirstOrDefault(
                                    i => i.SourceDT < DateTime.Now && (!i.DestinationDT.HasValue || i.DestinationDT > DateTime.Now))
                            })
                        .Select(x => new BedInWardViewModel
                            {
                                Name = x.BedTitle,
                                PatientName = x.InPatient == null ? "[Free]" : x.Patient.Patient.FirstName + " " + x.InPatient.Patient.LastName,
                                Admitted = x.InPatient == null ? "[NA]" : x.InPatient.SourceDT.ToString()
                            })
                        .ToList()
                })
            .Single();
