            //Hope this helps
            string a = "";
            string b = "mystring";
            string c = "mystring";
            string d = "mystring";
            bool isEqual = true;
            ArrayList array = new ArrayList();
            array.Add(a);
            array.Add(b);
            array.Add(c);
            array.Add(d);
            foreach (string stringMemeber in array)
            {
                if (string.IsNullOrEmpty(stringMemeber))
                {
                    continue;
                }
                else
                {
                    foreach (string NestedStringMember in array)
                    {
                        if (string.IsNullOrEmpty(NestedStringMember))
                        {
                            continue;
                        }
                        else
                        {
                            if (string.Compare(stringMemeber,NestedStringMember)!=0)
                            {
                                isEqual = false;
                                break;
                            }
                        }
                    }
                    if (!isEqual)
                    {
                        break;
                    }
                }
            }
            Console.WriteLine("The strings are equal: " + isEqual.ToString());
         
