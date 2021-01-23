    var inMemList = new List<string>();
    foreach (ObjectId attId in attCol)
                {
                    AttributeReference attRef(AttributeReference)tr.GetObject(attId, OpenMode.ForWrite);
                    string str = ("\n " + attRef.TextString);//here i get duplicate value
                }
    foreach(var text in inMemList.Distinct())
        ed.WriteMessage(text);
