    public IEnumerable<String> GetRuneStrings()
    {
    	foreach(RunePage rune in runePages)
    	{
    		if(rune.Slots != null && rune.Slots.Count > 0)
    		{
    			foreach(RuneSlot runeSlot in rune.Slots)
    			{
    				var runeName = staticApi.GetRune(RiotSharp.Region.lan, runeSlot.RuneId,    RuneData.tags, Language.es_ES).Name;				
    				yield return runeName;
    			}
    		 }
    		 yield return rune.Name;
    	}
    }
    
    public IEnumerable<String> GetAggregatedRuneStrings()
    {
        return GetRuneStrings().
    	    GroupBy(runeStr => runeStr).
    		Select(runeStrGroup => String.Format("{0} x {1}", runeStrGroup.First(), runStrGroup.Count()));
    }
    
    
    public void AddRuneStringsToRichTextBox()
    {
        richTextBox1.Text += String.Join(Environment.NewLine, GetAggregatedRuneStrings().ToArray());
    }
