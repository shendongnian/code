    XElement root = XElement.Load(strFileName);
    int total = 0;
    foreach(var eid in root.Descendants("EID").ToList())
    {
       int count = eid.Parent.Elements("EmpList").Count();
       Console.WriteLine(eid.Value + " " + count.ToString());
       total += count;
    }
    Console.WriteLine("Total EmpList's: " + total.ToString());
