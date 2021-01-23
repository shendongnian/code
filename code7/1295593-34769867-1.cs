    var pattern = "{0}.{0}+{1}(?<someGroup>{0}{3}){2,}";
    ObjectRegex<T> regex = new ObjectRegex<T>(pattern, IsPred0, IsPred1, IsPred2, IsPred3);
    var input = new T[] { /*objects go here*/ };
    var matches = regex.Matches(input);
    var match = regex.Match(input);
    var someGroup = match.Groups["someGroup"].Value;
    if(regex.IsMatch(input))
    {
      /*some code*/
    }
