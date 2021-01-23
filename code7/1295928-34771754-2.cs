    string xml = @"<Request>
        <Type>Delete</Type>
        <Client>
            <ClientId></ClientId>
            <Assignment>
                <AssignmentId></AssignmentId>
                <Assessments>
                    <AssessmentId>664449ba-21b9-e511-999d-d8fc934939fe</AssessmentId>
                    <AssessmentId>5ea8edd4-e1b9-e511-9af1-d8fc934939fe</AssessmentId>   
                    <AssessmentId>5ea8edd4-e1b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>865a13f8-e1b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>865a13f8-e1b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>06439800-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>06439800-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>f683aa08-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>f683aa08-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>063f8012-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>063f8012-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>16f7c329-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>16f7c329-e2b9-e511-9af1-d8fc934939fe</AssessmentId>       
                    <AssessmentId>76706838-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>76706838-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>86194741-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>86194741-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>66cf984f-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                    <AssessmentId>66cf984f-e2b9-e511-9af1-d8fc934939fe</AssessmentId>
                </Assessments>
            </Assignment>
        </Client>
    </Request>";
    
    XDocument xd = XDocument.Parse(xml);
    // get the distinct ones
    var distinctEls = xd.Root.Element("Client")
                             .Element("Assignment")
                             .Element("Assessments")
                             .Elements()
                             .Distinct(new XElComparer())
                             .ToList(); // ensure we actually get the list, not just the enumerator or elements we're about to remove
    // remove all children
    xd.Root.Element("Client")
           .Element("Assignment")
           .Element("Assessments")
           .Elements()
           .Remove();
    // add back our distinct list
    xd.Root.Element("Client")
           .Element("Assignment")
           .Element("Assessments")
           .Add(distinctEls);
    
    Console.WriteLine(xd);
    Console.ReadKey();
