    dynamic a = JsonConvert.DeserializeObject<dynamic>(json);
    foreach (dynamic entity in a.entities)
    {
        foreach (dynamic topLevelStructure in entity.Value)
        {
            if (topLevelStructure.Name == "claims")
            {
                var claim = topLevelStructure;
                foreach (dynamic claimField in claim.Value)
                {
                    string field_name = claimField.Name;
                }
            }
        }
    }
