    XElement p = new XElement( "Personne" );
    foreach(var property in Personn.GetType().GetProperties()) {
    XElement e = new XElement(prop.Name, prop.GetValue(P, null));
    e.Add(new XAttribute("xs:type", typeOf(Personne.prop)));
    p.Add(e);
    }
