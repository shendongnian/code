    public CibilEnquiry(string segmentTag, string version, string memberReferenceNumber)
    {
    	this.Tuef = new TUEF()
        {
            SegmentTag = segmentTag, 
            Version = version, 
            MemberReferenceNumber = memberReferenceNumber
        };
    	//initialize all of your class properties here
    	//simply it is the purpose of constructor to properly initialize the instance
    }
