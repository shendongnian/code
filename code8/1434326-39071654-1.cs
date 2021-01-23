    public class CertificateTrainingSchedule
    {
       public int Year {get; set;} // Certificate Class Property
       public int TrainingTypeId {get; set;} // Certificate Class Property
       public bool IsApproved {get; set;} // Certificate Class Property
       public DateTime EndDate {get; set;} // TrainingSchedule Class Property
    }
    var train = db.Certificates
                .Join(db.TrainingSchedules, cert => cert.CertificateId, ts => ts.CertificateId, (cert, ts) => new CertificateTrainingSchedule{ Year = cert.Year, TrainingTypeId = cert.TrainingTypeId, IsApproved = cert.IsApproved,EndDate = ts.EndDate})
                .Where(cts => cts.Year == year)
                .Where(cts => cts.TrainingTypeId == trainingTypeId)
                .Where(cts => cts.IsApproved)
                .Where(cts => cts.EndDate >= DateTime.Now)
                .Select(cts => new {cts.Year,cts.TrainingTypeId,cts.IsApproved})
                .Distinct() // Allowing anonymous type to avoid IEqualityComparer<Certificate>
                .Where(certMain => !db.Registrations.Where(s => s.EmployeeId == empId)
                                                    .Select(cert => new Certificate{Year = cert.Year,TrainingTypeId = cert.TrainingTypeId,IsApproved = cert.IsApproved})
                                                    .Any(cert => cert.CertificateId == certMain.CertificateId))
