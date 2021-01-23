    //
    // POCO to store in MongoDB
    public class Session
    {
    
        public DateTime? StartUTCTimestamp { get; set; }
    
        public DateTime? StartTimestamp { get; set; }
    
        public DateTime? EndTimestamp { get; set; }
        //
        // If the StartUTCDate is defined then return the number of "ticks" in the date
        [BsonElement("StartUTCTimestampTicks")]
        public Int64? StartUTCTimestampTicks 
        { 
            get 
            { 
                return (this.StartUTCTimestamp.HasValue) ?
                        (Int64?)this.StartUTCTimestamp.Value.Ticks : 
                        null; 
            } 
        }
        //
        // If the StartDate is defined then return the number of "ticks" in the date
        [BsonElement("StartTimestampTicks")]
        public Int64? StartTimestampTicks
        { 
            get 
            { 
                return (this.StartTimestamp.HasValue) ?
                        (Int64?)this.StartTimestamp.Value.Ticks : 
                        null; 
            } 
        }
        //
        // If the EndDate is defined then return the number of "ticks" in the date
        [BsonElement("EndTimestampTicks")]
        public Int64? EndTimestampTicks
        { 
            get 
            { 
                return (this.EndTimestamp.HasValue) ?
                        (Int64?)this.EndTimestamp.Value.Ticks : 
                        null; 
            } 
        }
    
        public void ToJSON(ref JsonTextWriter writer)
        {
            Session session = this;            
    
            writer.WriteStartObject(); // {
    
            if (session.StartUTCTimestamp.HasValue)
            {
                writer.WritePropertyName("StartUTCTimestamp");
                writer.WriteValue(session.StartUTCTimestamp);
                writer.WritePropertyName("StartUTCTimestampTicks");
                writer.WriteValue(session.StartUTCTimestampTicks);
            }
            if (session.StartTimestamp.HasValue)
            {
                writer.WritePropertyName("StartTimestamp");
                writer.WriteValue(session.StartTimestamp);
                writer.WritePropertyName("StartTimestampTicks");
                writer.WriteValue(session.StartTimestampTicks);
            }
            if (session.EndTimestamp.HasValue)
            {
                writer.WritePropertyName("EndTimestamp");
                writer.WriteValue(session.EndTimestamp);
                writer.WritePropertyName("EndTimestampTicks");
                writer.WriteValue(session.EndTimestampTicks);
            }
    
    
            writer.WriteEndObject(); // }
        }
    }
