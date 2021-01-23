    foreach (var element in elementen.Elements("Proces"))
            {
                Process process = new Process();
              
                    
                 process.Naam = element.Element("Naam").Value;
                 process.TemplatePath = element.Element("TemplatePath").Value;
                 process.OutputPath = element.Element("OutPutPath").Value;
                 process.OutputDocumentName = element.Element("OutputDocumentName").Value;
                 lijst.Add(process)
            }
