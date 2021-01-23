    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xml =
                    "<RichDBDS>" +
                      "<TrxDetailCard>" +
                        "<TRX_HD_Key>18683435</TRX_HD_Key>" +
                        "<Date_DT>2015-10-22T21:32:00.233+00:00</Date_DT>" +
                        "<TRX_Card_Key>15263569</TRX_Card_Key>" +
                        "<Total_Amt_MN>22.0000</Total_Amt_MN>" +
                        "<Result_CH>0    </Result_CH>" +
                        "<Result_Txt_VC>APPROVED</Result_Txt_VC>" +
                        "<Approval_Code_CH>0943253</Approval_Code_CH>" +
                      "</TrxDetailCard>" +
                      "<TrxDetailCard>" +
                        "<TRX_HD_Key>18683825</TRX_HD_Key>" +
                        "<Date_DT>2015-10-23T21:32:00.233+00:00</Date_DT>" +
                        "<TRX_Card_Key>15263569</TRX_Card_Key>" +
                        "<Total_Amt_MN>32.0000</Total_Amt_MN>" +
                        "<Result_CH>0    </Result_CH>" +
                        "<Result_Txt_VC>APPROVED</Result_Txt_VC>" +
                        "<Approval_Code_CH>093389</Approval_Code_CH>" +
                      "</TrxDetailCard>" +
                    "</RichDBDS>";
                XElement richDBDS = XElement.Parse(xml);
                XElement results = richDBDS.Elements("TrxDetailCard").Where(x => (decimal)x.Element("Total_Amt_MN") == (decimal)32.0000).FirstOrDefault();
     
            }
        }
    }
    ​
