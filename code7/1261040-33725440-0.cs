    static bool CheckLogin(string path, string username, string pwd)
    {
    return XDocument.Load(path).Root
    .Elements("user")
    .Any(x=>x.Element("username").Value==username && x.Element("password").Value==pwd);
    }
