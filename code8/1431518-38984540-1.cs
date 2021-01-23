    JObject person = JObject.Parse(@"{
      'name': null,
      'hobbies': ['Invalid content', 0.123456789]
    }");
    
    IList<string> messages;
    bool valid = person.IsValid(schema, out messages);
    // false
    // Invalid type. Expected String but got Null. Line 2, position 21.
    // Invalid type. Expected String but got Float. Line 3, position 51.
