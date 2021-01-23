    public string getJson() {
    	var publicationTable = new[] {
            new[] { 1, 2, 3, 4, 5 },
            new[] { 6, 7, 8, 9, 10 }
        };
    	return (new JavaScriptSerializer()).Serialize(publicationTable);
    }
