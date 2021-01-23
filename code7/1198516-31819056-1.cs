    var list = new List<Item>();
    list.Add(new Item() { correctIndex = 10, index = 11, text = "asdasd" });
    list.Add(new Item() { correctIndex = 10, index = 12, text = "asdasaad" });
    var questions = new List<Question>();
    questions.Add(new Question { enunciado = "alalal", CorrectOptionIndex = 3, options = list });
            
    var m = new MemoryStream();
    using (var sw = new StreamWriter(m))
    {
        var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        var serializer = new XmlSerializer(questions.GetType(), new XmlRootAttribute("quests"));
        serializer.Serialize(sw, questions, emptyNamepsaces );
        var xml = Encoding.UTF8.GetString(m.ToArray());
    }
