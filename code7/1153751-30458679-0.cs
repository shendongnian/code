    schema = schemaSet.Schemas().Cast<XmlSchema>().Single();
    XmlSchemaGroup g = schema.Items[21] as XmlSchemaGroup;
    XmlSchemaElement ge = g.Particle.Items[0] as XmlSchemaElement;
    XmlSchemaSimpleType gef = ge.ElementSchemaType as XmlSchemaSimpleType;
    XmlSchemaSimpleTypeContent gefc = gef.Content as XmlSchemaSimpleTypeContent;
    XmlSchemaSimpleTypeRestriction re = gefc as XmlSchemaSimpleTypeRestriction;
    XmlSchemaObjectCollection fac = re.Facets;
    foreach (var restriccion in fac)
    {
        Console.WriteLine(restriccion.GetType().ToString()+": {0}", (restriccion as dynamic).Value);
        //if (restriccion.GetType().Equals(typeof(XmlSchemaLengthFacet)))
        //{
        //    Console.WriteLine("length: {0}", (restriccion as XmlSchemaLengthFacet).Value);
        //}
        //else if (restriccion.GetType().Equals(typeof(XmlSchemaMinInclusiveFacet)))
        //{
        //    Console.WriteLine("minInclusive: {0}", (restriccion as XmlSchemaMinInclusiveFacet).Value);
        //}
        //else if (restriccion.GetType().Equals(typeof(XmlSchemaMaxInclusiveFacet)))
        //{
        //    Console.WriteLine("maxInclusive: {0}", (restriccion as XmlSchemaMaxInclusiveFacet).Value);
        //}
    }
    
