    PdfReader reader = new PdfReader(datasheet);
    // Get the fields from the reader (read-only!!!)
    AcroFields form = reader.AcroFields;
    // Loop over the fields and get info about them 
    StringBuilder sb = new StringBuilder();       
    foreach (string key in form.Fields.Keys) {
        sb.Append(key);
        sb.Append(": ");
        switch (form.GetFieldType(key)) {
            case AcroFields.FIELD_TYPE_CHECKBOX:
                sb.Append("Checkbox");
                break;
            case AcroFields.FIELD_TYPE_COMBO:
                sb.Append("Combobox");
                break;
            case AcroFields.FIELD_TYPE_LIST:
                sb.Append("List");
                break;
            case AcroFields.FIELD_TYPE_NONE:
                sb.Append("None");
                break;
            case AcroFields.FIELD_TYPE_PUSHBUTTON:
                sb.Append("Pushbutton");
                break;
            case AcroFields.FIELD_TYPE_RADIOBUTTON:
                sb.Append("Radiobutton");
                break;
            case AcroFields.FIELD_TYPE_SIGNATURE:
                sb.Append("Signature");
                break;
            case AcroFields.FIELD_TYPE_TEXT:
                sb.Append("Text");
                break;
            default:
                sb.Append("?");
                break;
        }
        sb.Append(Environment.NewLine);
    } 
    // Get possible values for field "CP_1"
    sb.Append("Possible values for CP_1:");
    sb.Append(Environment.NewLine);
    string[] states = form.GetAppearanceStates("CP_1");
    for (int i = 0; i < states.Length; i++) {
        sb.Append(" - ");
        sb.Append(states[i]);
        sb.Append(Environment.NewLine);
    }
    // Get possible values for field "category"
    sb.Append("Possible values for category:");
    sb.Append(Environment.NewLine);
    states = form.GetAppearanceStates("category");
    for (int i = 0; i < states.Length - 1; i++) {
        sb.Append(states[i]);
        sb.Append(", ");
    }
    sb.Append(states[states.Length - 1]);
