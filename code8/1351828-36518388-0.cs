    var str = "";
    var chars = new List<string>();
    var tee = StringInfo.GetTextElementEnumerator(str);
    while (tee.MoveNext())
        chars.Add(tee.GetTextElement());
