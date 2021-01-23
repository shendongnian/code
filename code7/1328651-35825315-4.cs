    dynamic a = JsonConvert.DeserializeObject<dynamic>(json);
    foreach (dynamic entity in a.entities)
    {
        foreach (dynamic topLevelStructure in entity.Value)
        {
            if (topLevelStructure.Name == "claims")
            {
                foreach (dynamic claimField in topLevelStructure.Value)
                {
                    var field_name = claimField.Name;
                    foreach (var p in claimField.Value)
                    {
                        var mainsnak = p.mainsnak;
                        var property = mainsnak.property.Value;
                        var datavalue = mainsnak.datavalue;
                        var value = datavalue.value.Value;
                        var type = datavalue.type.Value;
                    }
                }
            }
        }
    }
