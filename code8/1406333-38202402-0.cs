                return result
                    .Hits
                    .Select(c => new PatientInfo
                    {
                        Id = c.Source.Id,
                        Patient_Num = c.Source.Patient_Num,
                        First_Name = c.Source.First_Name,
                        Last_Name = c.Source.Last_Name,
                        Full_Name = c.Source.Full_Name,
                        Address = c.Source.Address,
                        City = c.Source.City,
                        State = c.Source.State,
                        Zip = c.Source.Zip,
                        Relation_Code = c.Source.Relation_Code,
                        DOB = c.Source.DOB,
                        Sex = c.Source.Sex,
                        IndexedOn = c.Source.IndexedOn,
                        Highlights = c.Highlights
                    })
                    .OrderByDescending(t => t.Highlights.Count).ToList();
