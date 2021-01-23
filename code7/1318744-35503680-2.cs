    var node = new Node {
        Person = new Person { Id = 1, Name = "Bob" },
        Language = new Language { Id = 10, Code = "en" },
        Nodes = new List<Node> {
                new Node {
                Person = new Person {  Id = 3, Name = "Mike"},
                Language = new Language {  Id = 11, Code = "es"},
                Nodes = new List<Node> {
                        new Node {
                        Person = new Person {  Id = 4, Name = "Alex"},
                        Language = new Language {  Id = 11, Code = "es"}
                    }
                }
            },
            new Node {
                Person = new Person {  Id = 5, Name = "Serge"},
                Language = new Language {  Id = 12, Code = "by"}
            }
        }
    };
            
    var nodeListDTO = mapper.Map<NodeListDTO>(node);
