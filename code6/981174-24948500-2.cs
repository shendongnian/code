    string xml = @"
    <MyClass>
        <eventID>1</eventID>
        <parentID>0</parentID>
        <name>Some name</name>
        <startTime>Some startTime</startTime>
        <duration>Some duration</duration>
        <status>Some status</status>
        <timedByUser>true</timedByUser>
        <eventType>1</eventType>
    </MyClass>
    <MyClass>
        <eventID>2</eventID>
        <parentID>0</parentID>
        <name>Some another name</name>
        <startTime>Some another startTime</startTime>
        <duration>Some another duration</duration>
        <status>Some another status</status>
        <timedByUser>false</timedByUser>
        <eventType>2</eventType>
    </MyClass>";
    
    var doc = XDocument.Parse(xml);
    
    var dataSource = doc.Elements("MyClass")
        .Select<XElement, MyClass>(
            (item) =>
            {
                var myClass = new MyClass();
    
                myClass.eventID = int.Parse(item.Element("eventID").Value);
                myClass.parentID = int.Parse(item.Element("parentID").Value);
                myClass.name = item.Element("name").Value;
                myClass.startTime = item.Element("startTime").Value;
                myClass.duration = item.Element("duration").Value;
                myClass.status = item.Element("status").Value;
                myClass.timedByUser = bool.Parse(item.Element("timedByUser").Value);
                myClass.eventType = int.Parse(item.Element("eventType").Value);
    
                return myClass;
            })
        .ToList<MyClass>();
