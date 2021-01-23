    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer xs = new XmlSerializer(typeof(MemberList));
                XmlTextReader reader = new XmlTextReader(FILENAME);
                MemberList  members = (MemberList)xs.Deserialize(reader);
            }
        }
        [XmlRoot("memberList")]
        public class MemberList
        {
            [XmlElement("groupID64")]
            public string groupID64 { get; set;}
            [XmlElement("groupDetails")] 
            public GroupDetails groupDetails { get; set;} 
            [XmlElement("nextPageLink")]
            public Text nextPageLink { get; set; }
            [XmlElement("members")]
            public Members members { get; set; }
        }
        [XmlRoot("groupDetails")]
        public class GroupDetails
        {
            [XmlElement("groupName")]
            public Text groupName { get; set; }
            [XmlElement("groupURL")]
            public Text groupURL { get; set; }
            [XmlElement("headline")]
            public Text headline { get; set; }
            [XmlElement("summary")]
            public Text summary { get; set; }
            [XmlElement("avatarIcon")]
            public Text avatarIcon { get; set; }
            [XmlElement("avatarMedium")]
            public Text avatarMedium { get; set; }
            [XmlElement("avatarFull")]
            public Text avatarFull { get; set; }
            [XmlElement("memberCount")]
            public int memberCount { get; set; }
            [XmlElement("membersInChat")]
            public int membersInChat { get; set; }
            [XmlElement("membersInGame")]
            public int membersInGame { get; set; }
            [XmlElement("membersOnline")]
            public int membersOnline { get; set; }
        }
        public class Text
        {
            [XmlText]
            public string text { get; set;}
        }
        [XmlRoot("members")]
        public class Members
        {
            [XmlElement("steamID64")]
            public List<string> steamID64 { get; set;}
        }
    }
    ​
