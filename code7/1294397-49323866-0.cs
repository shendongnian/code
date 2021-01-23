    public string DateString {
        set {
        // parse value here - de-ser from your chosen format
        // use constructor, eg, Timestamp= new System.DateTime(....);
        // or use one of the static Parse() overloads of System.DateTime()
        }
        get {
            return Timestamp.ToString("yyyy.MM.dd");  // serialize to whatever format you want.
        }
    }
