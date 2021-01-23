    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication11
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                string CSVData = "CRUISE-ID;DEP-PORT;DEP-NAME-PORT;DEP-DATE;DEP-DAY;DEP-WEEKDAY;DEP-TIME;ARR-PORT;ARR-NAME-PORT;ARR-DATE;ARR-DAY;ARR-WEEKDAY;ARR-TIME;ITIN-CD;AREA/DESTOR20160209BGIBGI;BGI;Bridgetown, Barbados;09/02/16;1;Tuesday;2000;POS;Port of Spain, Trinidad and Tobago;10/02/16;2;Wednesday;0900;U19M;CAR;OR20160209BGIBGI;POS;Port of Spain, Trinidad and Tobago;10/02/16;2;Wednesday;1700;RSU;Roseau, Dominica;11/02/16;3;Thursday;1000;U19M;CAR;OR20160209BGIBGI;RSU;Roseau, Dominica;11/02/16;3;Thursday;1800;STG;Saint George, Grenada;12/02/16;4;Friday;0800;U19M;CAR;OR20160209BGIBGI;STG;Saint George, Grenada;12/02/16;4;Friday;1800;FDF;Fort de France, Martinique;13/02/16;5;Saturday;0800;U19M;CAR;";
                List<string> ListData = CSVData.Split(';').ToList();
                int ElementNumber = int.Parse(Math.Ceiling(ListData.Count/19.0).ToString());
                StringBuilder XMLBuilder = new StringBuilder(5000);
                XMLBuilder.AppendFormat("<TopElement>");
                Console.WriteLine("<TopElement>");
                for (int n = 0; n < ElementNumber; n++)
                {
                    int m = n;
                    XMLBuilder.AppendFormat("<row>");
                    Console.WriteLine("<row>");
                    XMLBuilder.AppendFormat("<CODE>{0}</CODE>",m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<CODE>{0}</CODE>", m< ListData.Count ? ListData[m] : "" );
                    XMLBuilder.AppendFormat("<LOC-CD>{0}</LOC-CD>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<LOC-CD>{0}</LOC-CD>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PORT-CD>{0}</PORT-CD>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PORT-CD>{0}</PORT-CD>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<DESC>{0}</DESC>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<DESC>{0}</DESC>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<START-DT>{0}</START-DT>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<START-DT>{0}</START-DT>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<END-DT>{0}</END-DT>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<END-DT>{0}</END-DT>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<SHIP-CD>{0}</SHIP-CD>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<SHIP-CD>{0}</SHIP-CD>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PAXTYPE>{0}</PAXTYPE>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PAXTYPE>{0}</PAXTYPE>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<INVENTORIED>{0}</INVENTORIED>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<INVENTORIED>{0}</INVENTORIED>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<APPLY-TO>{0}</APPLY-TO>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<APPLY-TO>{0}</APPLY-TO>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<REGION-CD>{0}</REGION-CD>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<REGION-CD>{0}</REGION-CD>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PRICE-TYPE>{0}</PRICE-TYPE>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PRICE-TYPE>{0}</PRICE-TYPE>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PRICE-BASIS>{0}</PRICE-BASIS>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PRICE-BASIS>{0}</PRICE-BASIS>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PRICE-I>{0}</PRICE-I>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PRICE-I>{0}</PRICE-I>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PRICE-J>{0}</PRICE-J>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PRICE-J>{0}</PRICE-J>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PRICE-C>{0}</PRICE-C>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PRICE-C>{0}</PRICE-C>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PRICE-A>{0}</PRICE-A>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PRICE-A>{0}</PRICE-A>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<PRICE-S>{0}</PRICE-S>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<PRICE-S>{0}</PRICE-S>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("<DESC-LONG>{0}</DESC-LONG>", m++<ListData.Count?ListData[m]:"");
                    Console.WriteLine("<DESC-LONG>{0}</DESC-LONG>", m < ListData.Count ? ListData[m] : "");
                    XMLBuilder.AppendFormat("</row>");
                    Console.WriteLine("</row>");
                }
                Console.WriteLine("</TopElement>");
                XMLBuilder.AppendFormat("</TopElement>");
                Console.ReadLine();
            }
        }
    }
