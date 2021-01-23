    var xml = @"
    <data>
        <count>2</count>
        <facility>
            <typeId>1</typeId>
            <type>Beds</type>
            <quantity>0</quantity>
            <description>null</description>
        </facility>
        <facility>
            <typeId>2</typeId>
            <type>EDBeds</type>
            <quantity>0</quantity>
            <description>null</description>
        </facility>
    </data>";
    
    var xDocument = XDocument.Load( new StringReader( xml ) );
    var facilityElements = xDocument.Descendants().Where( x => x.Name == "facility" );
    
    // Count the elements
    var count = facilityElements.Count();
    
    foreach ( var facilityElement in facilityElements )
    {
        // Handle elements
    }
    
    // Adds an facility element
    var facility = new XElement( "facility" );
    var typeId = new XElement( "typeId" );
    typeId.SetValue(3);
    facility.Add( typeId );
    xDocument.Element( "data" ).Add( facility );
