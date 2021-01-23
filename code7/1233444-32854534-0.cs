    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<DataSample> samples = new List<DataSample>();
                string data = "9/26/2015,GROUP_1,0,0,0,0,0,0,0,0,0,0,12345.006,12345.006,27469.005,27469.005,27983.005,27983.005,28081.005," +
                              "0,0,0,28105.005,28105.005,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0\n";
                StringReader reader = new StringReader(data);
                string inputline = "";
                while ((inputline = reader.ReadLine()) != null)
                {
                    string[] dataArray = inputline.Split(new char[] { ',' });
                    DateTime startDate = DateTime.Parse(dataArray[0]);
                    startDate += new TimeSpan(8, 0, 0);
                    DateTime timeCounter = startDate;
                    string groupName = dataArray[1];
                    for (int i = 2; i < dataArray.Length; i++)
                    {
                        DataSample newSample = new DataSample();
                        samples.Add(newSample);
                        newSample.name = groupName;
                        newSample.time = timeCounter;
                        newSample.value = double.Parse(dataArray[i]);
                        timeCounter += new TimeSpan(0, 15, 0);
                    }
                }
            }
     
        }
        public class DataSample
        {
            public string name { get; set; }
            public DateTime time { get; set; }
            public double value { get; set; }
        }
    }
    ​
