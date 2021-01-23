    CodeMemberfield field = new CodeMemberField
      {
          Name = "YourPropertyName",
          Attributes = MemberAttributes.Public | MemberAttributes.Final,
          Type = new CodeTypeReference(typeof(YourClassName)),
      };
    field.Name += " { get; private set; }";
