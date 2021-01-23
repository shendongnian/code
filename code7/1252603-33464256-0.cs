    class MyListUser
        {
            public string Name;
            public int  Grades;
        }
    private List<MyListUser> ReadUserFile()
            {
                List<MyListUser> lstUser;
                string[] sMyData = File.ReadAllLines("Myfile.txt");
                if (sMyData != null)
                {
                    MyListUser oTmp;
                    string[] sTmp;
                    lstUser = new List<MyListUser>();
                    for (int i = 0; i < sMyData.GetLength(0); i++)
                    {
                        sTmp = Regex.Split(sMyData[i], ",");
                        //need some validation
                        if (sTmp != null && sTmp.GetLength(0) > 1)
                        {
                            oTmp = new MyListUser();
                            oTmp.Name = sTmp[0];
                            int.TryParse(sTmp[1], out oTmp.Grades );
                            lstUser.Add(oTmp);
                        }
                    }
                    return lstUser.OrderBy(o => o.Grades).ToList();
                }
                return null;
            }
