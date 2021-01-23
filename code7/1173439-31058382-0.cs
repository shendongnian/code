        static void Main(string[] args)
        {
            MyTest test = new MyTest();
            test.btn_hourfiles_click();
        }
    }
    class MyTest
    {
        private StreamWriter streamWriter;
        string[] hour = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" };
        public void btn_hourfiles_click()
        {
            string txt_DATE = "25-02-2015";
            string[] Data_List = { "12:05:10", "02:15:00", "14:15:22" };
            int sizeoflist = 3; // Data_List.Count(); //This is the list containing the data
            for (int i = 0; i < sizeoflist; i++)
            {
                string[] listsplit = Data_List[i].Split(':');
                for (int j = 0; j < 24; j++)
                {
                    if (listsplit[2] == hour[j])
                    {
                        string[] datesplit = txt_DATE.Split('-');//splits input date
                        var filename = datesplit[0] + '_' + datesplit[1] + '_' + datesplit[2] + '_' + hour[j] + ".dat";
                        streamWriter = new StreamWriter(new FileStream("C:\\" + filename, FileMode.Append, FileAccess.Write));
                    }
                }
            }
        }
    }
