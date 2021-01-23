    ((AliasedValue)_entity.Attributes["ab.new_costtobusiness"])  // Returns an AliasedValue
    .Value // Returns a Money but is actually an Object
    .ToString() // Calls the default ToString of Money which is just spit out the type name.
    // This should be correct:
    ((Money)((AliasedValue)_entity.Attributes["ab.new_costtobusiness"]).Value).Value.ToString()
