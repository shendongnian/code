        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            if (HttpContext.Current.Request.Files == null || HttpContext.Current.Request.Files.Count == 0 || HttpContext.Current.Request.Files[0].ContentLength == 0)
                results.Add(new ValidationResult("File is not selected or empty", new string[] { "NoFile" }));
            using (MemoryStream ms = new MemoryStream())
            {
                HttpContext.Current.Request.Files[0].InputStream.CopyTo(ms);
                ms.Position = 0;
                using (StreamReader reader = new StreamReader(ms))
                {
                    using (var csv = new CsvReader(reader))
                    {
                        var enumeraterecords = csv.GetRecords<TemporaryPersonCsv>();
                        if (enumeraterecords != null)
                        {
                            var records = enumeraterecords.ToList();
                            if (records == null || records.Count == 0)
                                results.Add(new ValidationResult("No records in file", new string[] { "NoRecords" }));
                            // find dublicates in CSV file
                            var dublicates = (records.GroupBy(p => p.Fullname.ToLower().Trim()).Where(p => p.Count() > 1).Select(p => p.Key)).ToList();
                            if (dublicates != null && dublicates.Count > 0)
                            {
                                foreach (var dublicateFullname in dublicates)
                                {
                                    results.Add(new ValidationResult(String.Concat("There are 2 or more records with fullname='", dublicateFullname, "' in your csv file. Please, fix your file and upload again."), new string[] { "DublicateRecords" }));
                                }
                            }
                            // find dublicates in TemporaryPersons and Persons tables
                            PlugandabandonEntities db = new PlugandabandonEntities();
                            foreach (var record in records)
                            {
                                if (db.TemporaryPerson.Where(p => p.Fullname.ToLower() == record.Fullname.ToLower()).Count() > 0)
                                    results.Add(new ValidationResult(String.Concat("Record with fullname='", record.Fullname, "' already exists in TemporaryPersons. Please, fix your file and upload again."), new string[] { "RecordExistsInTemporaryPerson" }));
                                if (db.Person.Where(p => p.Fullname.ToLower() == record.Fullname.ToLower()).Count() > 0)
                                    results.Add(new ValidationResult(String.Concat("Record with fullname='", record.Fullname, "' already exists in Persons. Please, fix your file and upload again."), new string[] { "RecordExistsInPersons" }));
                            }
                        }
                        else
                            results.Add(new ValidationResult("No records in file", new string[] { "NoRecords" }));
                    }
                    reader.DiscardBufferedData();
                }
            }
            HttpContext.Current.Request.Files[0].InputStream.Position = 0;
            return results;
        }
