    public void UpdateVoiceCommand(string ruleId, SrgsRule updatedRule, string grammarFileName)
    {
	    SrgsDocument grammarXmlDoc = new SrgsDocument(grammarFileName);
	
	    SrgsRulesCollection rules;
	    rules = grammarXmlDoc.Rules;
        if (rules.Contains(ruleId))
            rules.Remove(ruleId);	//Remove old grammar rule
	    rules.Add(newRule);		//Add replacement rule
	    saveSrgsDocument(GrammarFileName, grammarXmlDoc);
    }
