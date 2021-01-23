    [XmlElementAttribute("Italic", typeof(string))]        
    public string Italic { get; set; }
    [XmlElementAttribute("Bold", typeof(string))]
    public string Bold { get; set; }
    public string[] Content { 
	    get {
		    return new string[] { this.Italic, this.Bold };
	    }
    }
