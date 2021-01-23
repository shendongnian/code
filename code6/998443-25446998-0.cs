    var xmlDoc2 = new XmlDocument();
    xmlDoc2.Load(textBox1.Text);
    Dictionary<string, List<string>> hs = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);
    var node = xmlDoc2.SelectNodes("pdml/packet/proto[@name='ip']/@showname");
    foreach (XmlAttribute attribute1 in node)
    {
        string ip = attribute1.Value;
        var arr = ip.Split(); var src = arr[5]; var dst = arr[8];
        List<string> l;
        if (!hs.TryGetValue(src, out l))
        {
            hs[src] = l = new List();
        }
        l.Add(dst);
    }
