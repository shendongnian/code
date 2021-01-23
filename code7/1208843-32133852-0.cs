    string str = "";
    XDocument doc = XDocument.Load(filename);
    IEnumerable<XElement> elements = doc.Root.Elements();
    foreach (XElement e in elements)
    {
        if ((e.Name == "T_C_B") || (e.Name == "U_C_B"))
        {
             IEnumerable<XElement> nextElmt = e.Elements();
             foreach (XElement x in nextElmt)
             {
                  str += string.Format("{0}={1}", x.Name, x.Value);
                  str += "|";
             }
        }
    }
    
    str = str.Remove(str.Length - 1, 1);
    Console.WriteLine(str);
