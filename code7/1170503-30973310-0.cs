                XmlTextWriter writer = new XmlTextWriter(path, System.Text.Encoding.UTF8);
                writer.WriteStartDocument(true);
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 4;
    
                writer.WriteStartElement("My Entity"); /* It is a biggest one*/
                writer.WriteStartElement("User Info");
                writer.WriteStartElement("Name");
                writer.WriteString(userName);
                writer.WriteEndElement();
                writer.WriteStartElement("Tutor Name");
                writer.WriteString(tutorName);
                writer.WriteEndElement();
                writer.WriteEndElement();
    
                writer.WriteStartElement("Course Data"); /*This is where the exception points to*/
                foreach (UserCourse c in courses)
                {
                    String cn = c.Name;
                    writer.WriteStartElement(cn);
    
                    foreach (UserUnit u in c.Units)
                    {
                        writer.WriteStartElement(u.Name.ToString());
    
                        foreach (UserObjective o in u.Objectives)
                        {
                            writer.WriteStartElement(o.Name.ToString());
                            writer.WriteString(o.Score.ToString());
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
                writer.WriteEndElement();
    
                writer.WriteEndDocument();
                writer.Close();
