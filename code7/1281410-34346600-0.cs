    public class DialogueParser {
    
    	/// <summary>
    	/// XMLDocument Instance
    	/// </summary>
    	private XmlDocument xmldocument;
    
    	public DialogueParser()
    	{
    		//Populate XMLDocument Instance
    		this.xmldocument = new XmlDocument ();
    		this.xmldocument.LoadXml (this.loadDialogues());
    	}
    
    	/// <summary>
    	/// Loads the dialogues from file into TextStream.
    	/// </summary>
    	/// <returns>dialogues.xml content as text for parsing</returns>
    	public string loadDialogues()
    	{
    		TextAsset dialogues = (TextAsset) Resources.Load<TextAsset> ("dialogues");
    		return dialogues.text;
    	}
    
    	public void getConversation(int npcID, int conversationID)
    	{
    		XmlNode el = this.xmldocument.SelectSingleNode (".//dialogues/npc[@npcid='1']/conversation[@id='1']/message[@mid='2']/text/text()");
    		Debug.Log (el.Value);
    	}
    }
