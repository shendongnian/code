    public class Error
    {
        [JsonProperty]
        internal string response_code;
    
        internal string Response_code
        {
            get { return response_code; }
            set { response_code = value; }
        }
    
        [JsonProperty]
        internal string response_description;
    
        internal string Response_description
        {
            get { return response_description; }
            set { response_description = value; }
        }
    
        [JsonProperty]
        internal string agency_qualifier_code;
    
        internal string Agency_qualifier_code
        {
            get { return agency_qualifier_code; }
            set { agency_qualifier_code = value; }
        }
    
        [JsonProperty]
        internal string agency_qualifier_description;
    
        internal string Agency_qualifier_description
        {
            get { return agency_qualifier_description; }
            set { agency_qualifier_description = value; }
        }
    
        [JsonProperty]
        internal string reject_reason_code;
    
        internal string Reject_reason_code
        {
            get { return reject_reason_code; }
            set { reject_reason_code = value; }
        }
    
        [JsonProperty]
        internal string reject_reason_description;
    
        internal string Reject_reason_description
        {
            get { return reject_reason_description; }
            set { reject_reason_description = value; }
        }
    
        [JsonProperty]
        internal string follow_up_action_code;
    
        internal string Follow_up_action_code
        {
            get { return follow_up_action_code; }
            set { follow_up_action_code = value; }
        }
    
        [JsonProperty]
        internal string folow_up_description;
    
        internal string Folow_up_description
        {
            get { return folow_up_description; }
            set { folow_up_description = value; }
        }
    
        [JsonProperty]
        internal string details;
    
        internal string Details
        {
            get { return details; }
            set { details = value; }
        }
    }     
