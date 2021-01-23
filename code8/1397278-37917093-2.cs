    public class AodIdeal
    {
        public int PostID { get; set; }
        public string  dateposted { get; set; }
        public string Source { get; set; }
        // Rest of properties here
    
        public override string ToString()
        {
            StringBuilder ObjectStringBuilder = new StringBuilder();
            ObjectStringBuilder.AppendFormat("PostID  : {0}{1}", PostID, Environment.NewLine);
            ObjectStringBuilder.AppendFormat("dateposted  : {0}{1}",dateposted, Environment.NewLine);
            ObjectStringBuilder.AppendFormat("Source  : {0}{1}", Source, Environment.NewLine);
             
            // and so on
            return ObjectStringBuilder.ToString();
        }
    }
