    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication19
    {
        class Program
        {
            const string FILENAME = @"c:\temp\Test.xml";
            static void Main(string[] args)
            {
                jobs jobList = new jobs(){
                   jobList = new List<job>(){
                      new job() {
                       standard_fields = new StandardFields{
                           start_date = DateTime.Parse("2015-04-23"),
                           end_date = DateTime.Parse("2015-05-23"),
                           title = "Ad Titel",
                           reference = "Test offer Dutch-9483599",
                           job_description = "...",
                           profile_description = "...",
                           company_description = "...",
                           company_name = "MLV Partners",
                           application_email = "offre9483599.9252@mlvpartners.contactrh.com",
                           education_level = new CID() {id = 6, value = "Specialisatie"},
                           work_experience = new CID() {id = 6, value = "4-5 jaar"},
                           contract_type = new CID() {id = 2, value = "Tijdelijk"},
                           location = "...",
                           function = new CID() {id = 20500, value = "Informatiesystemen / telecommunicatie"},
                           sub_function = new CID() {id = 20518, value = "Ingenieur Studies / Ontwikkeling"},
                           sector = new CID() { id = 40000, value = "Informatica"},
                           sub_sector = new CID() { id = 40002, value = "Software-uitgever"},
                           id = 9483599
                       },
                       custom_fields = new CustomFields(){
                           recruiter_id = "Recruiter ID"
                       }
                       }
                   }
               };
               XmlSerializer serializer = new XmlSerializer(typeof(jobs));
               StreamWriter writer = new StreamWriter(FILENAME);
               XmlSerializerNamespaces _ns = new XmlSerializerNamespaces();
               //_ns.Add("", "");
               //serializer.Serialize(writer, icp, _ns);
               serializer.Serialize(writer, jobList);
               writer.Flush();
               writer.Close();
               writer.Dispose();
               XmlSerializer xs = new XmlSerializer(typeof(jobs));
               XmlTextReader reader = new XmlTextReader(FILENAME);
               jobs  newJobs = (jobs)xs.Deserialize(reader);
                     
            }
        }
        [XmlRoot("jobs")]
        public class jobs
        {
            [XmlElement("job")]
            public List<job> jobList { get; set; }
        }
        [XmlRoot("job")]
        public class job
        {
            [XmlElement("standard_fields")]
            public StandardFields standard_fields { get; set; }
            [XmlElement("custom_fields")]
            public CustomFields custom_fields { get; set; }
        }
        [XmlRoot("custom_fields")]
        public class CustomFields
        {
            public string recruiter_id { get; set; }
        }
        [XmlRoot("standard_fields")]
        public class StandardFields
        {
            [XmlElement("start_date")]
            public DateTime start_date { get; set; }
            [XmlElement("end_date")]
            public DateTime end_date { get; set; }
            [XmlElement("title")]
            public string title { get; set; }
            [XmlElement("reference")]
            public string reference { get; set; }
            [XmlElement("job_description")]
            public string job_description { get; set; }
            [XmlElement("profile_description")]
            public string profile_description { get; set; }
            [XmlElement("company_description")]
            public string company_description { get; set; }
            [XmlElement("company_name")]
            public string company_name { get; set; }
            [XmlElement("application_email")]
            public string application_email { get; set; }
            [XmlElement("education_level")]
            public CID education_level { get; set; }
            [XmlElement("work_experience")]
            public CID work_experience { get; set; }
            [XmlElement("contract_type")]
            public CID contract_type { get; set; }
            [XmlElement("location")]
            public string location { get; set; }
            [XmlElement("function")]
            public CID function { get; set; }
            [XmlElement("sub_function")]
            public CID sub_function { get; set; }
            [XmlElement("sector")]
            public CID sector { get; set; }
            [XmlElement("sub_sector")]
            public CID sub_sector { get; set; }
            [XmlElement("id")]
            public int id { get; set; }
        }
        public class CID
        {
            [XmlText]
            public string value { get; set; }
            [XmlAttribute("id")]
            public int id { get; set; }
        }
      
    }
