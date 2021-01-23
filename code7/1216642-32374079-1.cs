    MyTemplate template = new MyTemplate 
    {
       Session = new Dictionary<string, object>
       {
          { "Email", "some@email.com" }
       }
    };
    template.Initialize();
    string body = template.TransformText();
