    CodeTypeDeclaration enumType = new CodeTypeDeclaration("MyEnum");
    enumType.IsEnum = true;
    enumType.BaseTypes.Add(typeof(long));
    enumType.Members.Add(new CodeMemberField("MyEnum", "First"));
    enumType.Members.Add(new CodeMemberField("MyEnum", "Second"));
    enumType.Members.Add(new CodeMemberField("MyEnum", "Third"));
