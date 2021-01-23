    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string identification =
                   "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                   "<EN:eDWR" +
                   " xmlns:EN=\"urn:us:net:exchangenetwork\"" +
                   " xmlns:SDWIS=\"http://www.epa.gov/sdwis\"" +
                   " xmlns:ns3=\"http://www.epa.gov/xml\"" +
                   " xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" +
                   "/>";
                XDocument doc = XDocument.Parse(identification);
                XElement eDWR = doc.Elements().Where(x => x.Name.LocalName == "eDWR").FirstOrDefault();
                XNamespace EN = eDWR.GetNamespaceOfPrefix("EN");
                XNamespace SDWIS = eDWR.GetNamespaceOfPrefix("SDWIS");
                XNamespace ns3 = eDWR.GetNamespaceOfPrefix("ns3");
                XNamespace xsi = eDWR.GetNamespaceOfPrefix("xsi");
                DataTable dt = QueryDataBase();
                foreach (DataRow row in dt.AsEnumerable())
                {
                    XElement submission = new XElement(EN + "Submission");
                    submission.Add(new object[] {
                    new XAttribute(EN + "submissionFileCreatedDate", row.Field<DateTime>("submissionFileCreatedDate")),
                    new XAttribute(EN + "submissionFileName", row.Field<string>("submissionFileName")),
                    new XAttribute(EN + "submissionID", row.Field<int>("submissionID"))
                    });
                    eDWR.Add(submission);
                    XElement LabAccreditation = new XElement(EN + "LabIdentification",new object[] {
                        new XElement(EN + "LabAccreditationIdentifier", row.Field<string>("LabAccreditationIdentifier")),
                        new XElement(EN + "LabAccreditationAuthorityName", row.Field<string>("LabAccreditationAuthorityName"))
                    });
                    XElement labReport = new XElement(EN + "LabReport");
                    XElement labIdentification = new XElement(EN + "LabIdentification");
                    submission.Add(labReport);
                    labReport.Add(labIdentification);
                    labIdentification.Add(LabAccreditation);
                    XElement sampleIdentification = new XElement(EN + "SampleIdentification", new object[] {
                        new XElement(EN + "LabSampleIdentifier", row.Field<int>("LabSampleIdentifier")),
                        new XElement(EN + "PWSIdentifier", row.Field<string>("PWSIdentifier")),
                        new XElement(EN + "PWSFacilityIdentifier", row.Field<string>("PWSFacilityIdentifier")),
                        new XElement(EN + "SampleRuleCode", row.Field<string>("SampleRuleCode")),
                        new XElement(EN + "SampleMonitoringTypeCode", row.Field<string>("SampleMonitoringTypeCode"))
                     });
                    XElement sample = new XElement(EN + "Sample");
                    labReport.Add(sample);
                    XElement RecordID = new XElement(SDWIS + "RecordID", row.Field<int>("RecordID"));
                    sample.Add(RecordID);
                    sample.Add(sampleIdentification);
                    
                }
     
                doc.Save(FILENAME);
            }
            static DataTable QueryDataBase()
            {
                DataTable dt = new DataTable();
                //Here is an example of getting a datatable from a database
                string SQL = "Enter Your SQL Here";
                string connStr = "Enter your database connection string here";
                //uncomment instructions below
                //SqlDataAdapter adapter = new SqlDataAdapter(SQL, connStr);
                //adapter.Fill(dt);
                //I will build a dummy datatable for your test case
                dt.Columns.Add("submissionFileCreatedDate", typeof(DateTime));
                dt.Columns.Add("submissionFileName", typeof(string));
                dt.Columns.Add("submissionID", typeof(int));
                dt.Columns.Add("LabAccreditationIdentifier", typeof(string));
                dt.Columns.Add("LabAccreditationAuthorityName", typeof(string));
                dt.Columns.Add("RecordID", typeof(int));
                dt.Columns.Add("LabSampleIdentifier", typeof(int));
                dt.Columns.Add("PWSIdentifier", typeof(string));
                dt.Columns.Add("PWSFacilityIdentifier", typeof(string));
                dt.Columns.Add("SampleRuleCode", typeof(string));
                dt.Columns.Add("SampleMonitoringTypeCode", typeof(string));
                dt.Rows.Add(new object[] {
                    DateTime.Parse("2012-07-21"),
                    "B_14271BJB.csv",
                    1,
                    "OR100024",
                    "STATE",
                    155628,
                    123321,
                    "OR4100237",
                    "DIST-A",
                    "TC",
                    "RP"
                });
                return dt;
            }
        }
    }
    ​
