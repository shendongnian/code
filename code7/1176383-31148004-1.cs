    // 1. Have a class to hold your data
    class FieldProperty
    {
    	public string Value { get; set; }
    	public int LengthRequired { get; set; }
        public string RightPaddedValue
        {
            get { return Value.PadRight(LengthRequired, ' '); }
        }
    }
    // 2. Fill your data into a dictionary somehow... for example:
    Dictionary<Fields, FieldProperty> fields = new Dictionary<Fields, FieldProperty>
	{
		{ 
			Fields.TRANSMITTERCONTACTPHONEEXT, 
			new FieldProperty {
				Value = TransmitterContactTelephoneExtension,
				LengthRequired = TransmitterContactTelephoneExtensionLength
			}
		},
		{ 
			Fields.TRANSMITTERFEIN,
    		new FieldProperty {
    			Value = TransmitterFEIN,
    			LengthRequired = TransmitterFEINLength
    		}
		}
	};
    // 3. Then use the data from that dictionary in your code:
    FieldProperty property = fields[selectedField];
    property.RightPaddedValue; // use RightPaddedValue
