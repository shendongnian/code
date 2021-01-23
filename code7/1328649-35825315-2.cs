    dynamic a = JsonConvert.DeserializeObject<dynamic>(json);
    foreach (dynamic entity in a.entities)
    {
        foreach (dynamic topLevelStructure in entity.Value)
        {
            if (topLevelStructure.Name == "claims")
            {
                foreach (dynamic claim in topLevelStructure.Value)
                {
                    var field_name = claim.Name;
                    foreach (var p in claim.Value)
                    {
                        var mainsnak = p.mainsnak;
                        var property = mainsnak.property.Value;
                        var datavalue = mainsnak.datavalue;
                    }
                }
            }
        }
    }
