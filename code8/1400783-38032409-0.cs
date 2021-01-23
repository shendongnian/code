    void ReadRecursive(JToken token, ref CommunicationMessage root)
    {
        var p = token as JProperty;
        if (p != null && p.Name == "Skill")
        {
            foreach (JArray child in p.Children())
            {
                foreach (JObject skill in child.Children())
                {
                    // Create/add a Skill message instance for current Skill (JObject)
                    var skillMsg = new CommunicationMessage { Key = p.Name };
                    // Populate Childs for current skill instance
                    skillMsg.Childs = new List<CommunicationMessage>();
                    foreach (JProperty skillProp in skill.Children())
                    {
                        skillMsg.Childs.Add(new CommunicationMessage
                        {
                            Key = skillProp.Name,
                            Value = (string)skillProp.Value
                        });
                    }
                    root.Childs.Add(skillMsg);
                }
            }
        }
        // Recurse
        foreach (JToken child in token.Children())
            ReadRecursive(child, ref root);
    }
