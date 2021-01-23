    string nameValues = "|||zeeshan|1||ali|2||ahsan|3|||";
                string[] nameArray = nameValues.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, string> dic = new Dictionary<string, string>();
                int i = 0;
                foreach (string item in nameArray)
                {
                    if (i < nameArray.Length - 1)
                        dic.Add(nameArray[i], nameArray[i + 1]);
                    i = i + 2;
                }
