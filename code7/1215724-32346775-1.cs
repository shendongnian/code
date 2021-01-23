      String text =
        @"public var any:int = 0;
          public var anyId:Number = 2;
          public var theEnd:Vector.<uint>;
          public var test:Boolean = false;
          public var others1:Vector.<int>;
          public var firstValue:CustomType;
          public var field2:Boolean = false;";
      List<Property> result = text
        .Split(new Char[] {'\r','\n'}, StringSplitOptions.RemoveEmptyEntries)
        .Select(line => {
           int varIndex = line.IndexOf("var") + "var".Length;
           int columnIndex = line.IndexOf(":") + ":".Length;
           int equalsIndex = line.IndexOf("="); // + "=".Length;
           // '=' can be absent
           equalsIndex = equalsIndex < 0 ? line.Length : equalsIndex + "=".Length;
           return new Property() {
             Name = line.Substring(varIndex, columnIndex - varIndex - 1).Trim(),
             Type = line.Substring(columnIndex, columnIndex - varIndex - 1).Trim(),
             Value = line.Substring(equalsIndex).Trim(' ', ';')
           };
        })
        .ToList();
