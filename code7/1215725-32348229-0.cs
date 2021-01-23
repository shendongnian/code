    var str = "public var any:int = 0;\r\npublic var anyId:Number = 2;\r\npublic var theEnd:Vector.<uint>;\r\npublic var test:Boolean = false;\r\npublic var others1:Vector.<int>;\r\npublic var firstValue:CustomType;\r\npublic var field2:Boolean = false;\r\npublic var secondValue:String = \"\";\r\npublic var isWorks:Boolean = false;";
	var rx = new Regex(@"(?<=\s*var\s*)(?<name>[^=:\n]+):(?<type>[^;=\n]+)(?:=(?<value>[^;\n]+))?");
    var coll = rx.Matches(str);
    var props = new List<Property>();
    foreach (Match m in coll)
        props.Add(new Property(m.Groups["name"].Value,m.Groups["type"].Value, m.Groups["value"].Value));
    foreach (var item in props)
       	Console.WriteLine("Name = " + item.Name + ", Type = " + item.Type + ", Value = " + item.Value);
