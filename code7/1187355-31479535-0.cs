      String myXML = @" <?xml version='1.0' encoding='utf-8' ?> 
                <activities>
                  <task>
                    <name> Task1 </name>
                    <time> 00:00 </time>
                    <subtask>
                      <name> Task1 - subtask1 </name>
                      <time> 00:00 </time>
                    </subtask>
                    <subtask>
                      <name> Task1 - subtask2 </name>
                      <time> 00:00 </time>
                    </subtask>
                  </task>
                  <task>
                    <name> Task2 </name>
                    <time> 00:00 </time>
                    <subtask>
                      <name> Task2 - subtask1 </name>
                      <time> 00:00 </time>
                    </subtask>
                  </task>
                </activities>";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(myXML);
            XmlNodeList items = doc.DocumentElement.SelectNodes("//Task/subtask");
