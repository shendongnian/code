        private List<String> myList;
        private void Init()
        {
            myList = new List<string>();
            myList.Add("foo/0000-0000-0001/111_Age_3_20150518T0800-0400.txt");
            myList.Add("foo/0000-0000-0002/222_Bal_3_20120518T0800-0400.txt");
            myList.Add("foo/0000-0000-0003/333_DDS_3_20140518T0800-0400.txt");
        }
        private string[] filtered()
        {
            var list = new List<String>();
            foreach (var line in myList)
            {
                var split1 = line.Split('/');
                if (split1.Length == 3)
                {
                    var split2 = split1[2].Split('_');
                    if (split2.Length == 4)
                    {
                        list.Add(split2[0]);
                    }
                }
            }
            return list.ToArray();
        }
