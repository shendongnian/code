    Entity_Spatial es = new Entity_Spatial();
    es.Ent_Sys = "ID0";
    Spatial_Element se = new Spatial_Element();
    Spelement_Unit unit = new Spelement_Unit();
    NewOrdinate ordinate = new NewOrdinate();
    unit.type_unit = "blabla";
    ordinate.X = "500";
    ordinate.Y = "800";
    ordinate.Num_Geopoint ="1233";
    unit.newOrdinate = ordinate;
    se.units.Add(unit);
    es.Items.Add(se);
    
    XmlSerializer xs = new XmlSerializer(typeof(Entity_Spatial));
    xs.Serialize(XmlWriter.Create(@"C:\asd.xml"), es);
    
    Entity_Spatial es2 = (Entity_Spatial)xs.Deserialize(XmlReader.Create(@"C:\test.xml"));
