    using System;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
       public class Program
       {
          static void Main(string[] args)
          {
             XmlSerializer oSerializer = new XmlSerializer(typeof(ConstituencyResults));
             FileStream oFileStream = new FileStream("XMLFile1.xml", FileMode.Open);
             ConstituencyResults obj = (ConstituencyResults)oSerializer.Deserialize(oFileStream);
             int iCnt = 0;
             Console.WriteLine("Name : " + obj.ConstituencyResult.ConstituencyName);
             Console.WriteLine("ID : " + obj.ConstituencyResult.ConsituencyId);
         
             foreach (var v in obj.ConstituencyResult.Results)
             {
                iCnt++;
                Console.WriteLine("");
                Console.WriteLine("Record #" + iCnt.ToString());
                Console.WriteLine("   PartyCode : " + v.PartyCode);
                Console.WriteLine("   Share : " + v.Share);
                Console.WriteLine("   Votes : " + v.Votes);
             }
             Console.ReadKey();
          }
       }
    }
