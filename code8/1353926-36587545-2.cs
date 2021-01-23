                string s = "{{Name Mike} {age 19} {gender male}}";
                string[] s2 = s.Replace("{", "").Replace("}", "").Split(' ');
    
                if (!File.Exists("x.xml"))
                {
                    TextWriter tw = new StreamWriter("x.xml", true);
                    tw.WriteLine("<root>\n</root>");
                    tw.Close();
                }
    
                for (int i = 0; i < s2.Length; i++)
                {
    
                    XDocument doc = XDocument.Load("x.xml");
                    XElement rt = doc.Element("root");
                    XElement elm = rt.Element(s2[i]);
    
                    if (elm != null)
                    {
                        elm.SetValue(s2[i + 1]);
                    }
                    else
                    {
                        XElement x = new XElement(s2[i], s2[i + 1]);
                        rt.Add(x);
                    }
    
                    doc.Save("x.xml");
                    i++;
                }
