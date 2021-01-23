    public class JobStatusListTask : IXmlSerializable
    {
        public JobListSettings ListSettings;
        public List<JobFilterCriteria> Filters;
        public JobStatusListTask()
        {
            Filters = new List<JobFilterCriteria>();
            Filters.Add(new JobFilterCriteria("STATUS", CriteriaOperator.Equal, "ERROR"));
        }
        public JobStatusListTask(JobListSettings settings) : this()
        {
            ListSettings = settings;
        }
        
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Filters");
            foreach(var item in Filters)
            {
                writer.WriteStartElement("Criteria", string.Format("Criteria_{0}", Count++));
                writer.WriteAttributeString("Parameter", Parameter);
                writer.WriteAttributeString("Operator", Operator.ToString());
                writer.WriteAttributeString("Value", Value);
            }
            writer.WriteEndElement();
        }
    }
