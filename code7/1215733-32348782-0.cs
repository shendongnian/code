    var input= @"public var any:int = 0;
                public var anyId:Number = 2;
                public var theEnd:Vector.<uint>;
                public var test:Boolean = false;
                public var others1:Vector.<int>;
                public var firstValue:CustomType;
                public var field2:Boolean = false;
                public var secondValue:String = """";
                public var isWorks:Boolean = false;";
    var pattern= @"\s*(?<vis>\w+?)\s+var\s+(?<name>\w+?)\s*:\s*(?<type>\S+?)(\s*=\s*(?<value>\S+?))?\s*;"
    var regex = new Regex(pattern, RegexOptions.Multiline);
    var results=regex.Matches(input);
    foreach (Match m in results)
    {
        var g = m.Groups;
        Console.WriteLine($"{g["name"],-15} {g["type"],-10} {g["value"],-10}");
    }
    var properties = (from m in results.OfType<Match>()
                        let g = m.Groups
                        select new Property
                        {
                            Name = g["name"].Value,
                            Type = g.["type"].Value,
                            Value = g["value"].Value
                        })
                        .ToList();
