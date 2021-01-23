    var list = new List<Q100Class.Item>();
    list.Add(new Q100Class.Item() { correctIndex = 10, index = 11, text = "asdasd" });
    list.Add(new Q100Class.Item() { correctIndex = 10, index = 12, text = "asdasaad" });
    var questions = new List<Q100Class.Question>();
    questions.Add(new Q100Class.Question { enunciado = "alalal", CorrectOptionIndex = 3, options = list });
            
    var m = new MemoryStream();
    using (var sw = new StreamWriter(m))
    {
        var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(questions.GetType(), new XmlRootAttribute("quests"));
        serializer.Serialize(sw, questions, emptyNamepsaces );
        var xml = Encoding.UTF8.GetString(m.ToArray());
    }
