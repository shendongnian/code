    foreach (var element in xml.Descendants("prompt"))
    {
        Queue<string> pauses = new Queue<string>(Regex.Matches(element.Value, @"\[pause *= *\d+\]")
            .Cast<Match>()
            .Select(m => m.Value));
        Queue<string> text = new Queue<string>(element.Value.Split(pauses.ToArray(), StringSplitOptions.None));
        element.RemoveAll();
        while (text.Any())
        {
            element.Add(new XText(text.Dequeue()));
            if (pauses.Any())
                element.Add(new XElement("break", new XAttribute("time", Regex.Match(pauses.Dequeue(), @"\d+"))));
        }
    }
