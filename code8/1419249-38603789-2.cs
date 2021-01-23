    var inMemList = new List<string>();
    foreach (ObjectId attId in attCol)
    {
        AttributeReference attRef = (AttributeReference)tr.GetObject(attId, OpenMode.ForWrite);
        inMemList.Add(attRef.TextString);
    }
    foreach(var text in inMemList.Distinct())
        ed.WriteMessage(string.Format("\n {0}", text));
