    var results = from job in xmlDoc.Root.Elements("Control")
                  let Repairer = job.Parent.Elements("Repairer").FirstOrDefault()
                  select new Job
                       {
                          Username = (string)job.Element("Username"),
                          Password = (string)job.Element("Password"),
                          RepairerName = (string)Repairer.Element("RepairerName"),
                          RepairerAddress = (string)Repairer.Element("RepairerAddress"),
                          RepairerTelephone = (string)Repairer.Element("RepairerTelephone")
                       };
