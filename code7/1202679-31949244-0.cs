        public static DataTable Read(XmlReader xmlReader, Func<bool> continueProcess)
        {
            DataTable dtManagersEducation = new DataTable();
            dtManagersEducation.TableName = "ManagersEducation";
            dtManagersEducation.Columns.Add("ManagerId");
            dtManagersEducation.Columns.Add("Institution");
            dtManagersEducation.Columns.Add("DegreeType");
            dtManagersEducation.Columns.Add("Emphasis");
            dtManagersEducation.Columns.Add("Year");
            bool inManagerDetail = false;
            string managerId = null;
            DataRow drManagersEducation = null;
            bool readNext = true;
            while ((!readNext || xmlReader.Read()) && continueProcess())
            {
                readNext = true;
                if (xmlReader.NodeType == XmlNodeType.Element)
                {
                    if (!xmlReader.IsEmptyElement)
                    {
                        if (xmlReader.Name == "ManagerDetail")
                        {
                            inManagerDetail = true;
                        }
                        else if (xmlReader.Name == "ManagerId")
                        {
                            var value = xmlReader.ReadElementContentAsString();
                            readNext = false;
                            if (inManagerDetail)
                                managerId = value;
                        }
                        else if (xmlReader.Name == "School")
                        {
                            var value = xmlReader.ReadElementContentAsString();
                            readNext = false;
                            if (drManagersEducation != null)
                                drManagersEducation["Institution"] = value;
                        }
                        else if (xmlReader.Name == "Year")
                        {
                            var value = xmlReader.ReadElementContentAsString();
                            readNext = false;
                            if (drManagersEducation != null)
                                drManagersEducation["Year"] = value;
                        }
                        else if (xmlReader.Name == "Degree")
                        {
                            var value = xmlReader.ReadElementContentAsString();
                            readNext = false;
                            if (drManagersEducation != null)
                                drManagersEducation["DegreeType"] = value;
                        }
                        else if (xmlReader.Name == "Major")
                        {
                            var value = xmlReader.ReadElementContentAsString();
                            readNext = false;
                            if (drManagersEducation != null)
                                drManagersEducation["Emphasis"] = value;
                        }
                        else if (xmlReader.Name == "CollegeEducation")
                        {
                            if (managerId != null)
                            {
                                drManagersEducation = dtManagersEducation.NewRow();
                                drManagersEducation["ManagerId"] = managerId;
                            }
                        }
                    }
                }
                else if (xmlReader.NodeType == XmlNodeType.EndElement)
                {
                    if (xmlReader.Name == "ManagerDetail")
                    {
                        inManagerDetail = false;
                        managerId = null;
                    }
                    else if (xmlReader.Name == "CollegeEducation")
                    {
                        if (drManagersEducation != null)
                            dtManagersEducation.Rows.Add(drManagersEducation);
                        drManagersEducation = null;
                    }
                }
            }
            return dtManagersEducation;
        }
