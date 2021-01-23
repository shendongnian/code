    string xml = @"<Students>
                <Student ID=""100"">
                    <Name>Arul</Name>
                    <Mark>90</Mark>
                </Student>
                <Student>
                    <Name>Arul2</Name>
                    <Mark>80</Mark>
                </Student>
            </Students>";
    dynamic students = DynamicXmlExt.Parse(xml);
    int id = (int)students.Student[0].ID;
    int mark = (int)students.Student[0].Mark;
    string name = (string)students.Student[1].Name;
