    using Chronic;
    public class BetterDateTimeRecognizer<T> : RecognizePrimitive<T> where T : class
    {
       private CultureInfo _culture;
       private Parser _parser;
    
       public BetterDateTimeRecognizer(IField<T> field, CultureInfo culture) 
              : base(field)
       {
          _culture = culture;
          _parser = new Chronic.Parser();
       }
    
       public override string Help(T state, object defaultValue)
       {
         var prompt = new Prompter<T>(_field.Template(TemplateUsage.DateTimeHelp), _field.Form, null);
         var args = HelpArgs(state, defaultValue);
         return prompt.Prompt(state, _field.Name, args.ToArray());
    
       }
    
       public override TermMatch Parse(string input)
       {
         TermMatch match = null;
         // the original code
         //DateTime dt;
         //if (DateTime.TryParse(input, out dt))
         //{
         //    match = new TermMatch(0, input.Length, 1.0, dt);
         //}
    
         var parse = _parser.Parse(input);
         if (parse != null && parse.Start.HasValue)
         {
             match = new TermMatch(0, input.Length, 1.0, parse.Start.Value);
         }
                
         return match;
      }
    
      public override IEnumerable<string> ValidInputs(object value)
      {
         yield return ValueDescription(value);
      }
    
      public override string ValueDescription(object value)
      {
         return ((DateTime)value).ToString(CultureInfo.CurrentCulture.DateTimeFormat);
      }
    }
