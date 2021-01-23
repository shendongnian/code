    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    namespace Data
    {
        public class DataList
        {
            public List<Data> lData { get; set; }
            public bool WriteToCSV(string strPath)
            {
                bool ret = false;
                try
                {
                    List<Data> lKids = this.lData.Where(x => x.Age < 18).ToList();
                    List<Data> lAdults = this.lData.Where(x => x.Age >= 18).ToList();
                    if (lKids.Count > 0)
                    {
                        string strFilePath = strPath + "Kids.csv";
                        using (StreamWriter sw = new StreamWriter(strFilePath))
                        {
                            foreach (Data p in lKids)
                            {
                                string strRow = (char)34 + p.Name + (char)34 + "," + (char)34 + p.LastName + (char)34 + "," + p.Age.ToString();
                                sw.WriteLine(strRow);
                            }
                        }
                        ret = true;
                    }
                    if (lAdults.Count > 0)
                    {
                        string strFilePath = strPath + "Adults.csv";
                        using (StreamWriter sw = new StreamWriter(strFilePath))
                        {
                            foreach (Data p in lAdults)
                            {
                                string strRow = (char)34 + p.Name + (char)34 + "," + (char)34 + p.LastName + (char)34 + "," + p.Age.ToString();
                                sw.WriteLine(strRow);
                            }
                        }
                        ret = true;
                    }
                }
                catch
                {
                    ret = false;
                }
                return ret;
            }
        }
        public class Data
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public Data(string name, string lastname, int age)
            {
                Name = name;
                LastName = name;
                Age = age;
            }
        }
    }
