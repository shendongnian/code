    // 1. Have a class to hold your data
    class FieldData
    {
    	public string Value { get; set; }
    	public int LengthRequired { get; set; }
        public string RightPaddedValue
        {
            get { return Value.PadRight(LengthRequired, ' '); }
        }
    }
    // 2. Fill your data into a dictionary somehow... for example:
    Dictionary<Fields, FieldData> fields = new Dictionary<Fields, FieldData>
	{
		{ 
			Fields.TRANSMITTERCONTACTPHONEEXT, 
			new FieldData {
				Value = TransmitterContactTelephoneExtension,
				LengthRequired = TransmitterContactTelephoneExtensionLength
			}
		},
		{ 
			Fields.TRANSMITTERFEIN,
    		new FieldData {
    			Value = TransmitterFEIN,
    			LengthRequired = TransmitterFEINLength
    		}
		}
	};
    // 3. Then use the data from that dictionary in your code:
    FieldData data = fields[selectedField];
    data.RightPaddedValue; // use RightPaddedValue
