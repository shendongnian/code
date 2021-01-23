    public class MyScorer : StandardConstructorScorer
    {
        public override int Score(IContext context, ConstructorInjectionDirective directive)
        {
            //has more than one constructor
            //and the constructor being considered is parameterless
            if (directive.Constructor.GetType().GetConstructors().Count() > 1 
                && !directive.Targets.Any())
            {
                //give it a low score
                return Int32.MinValue;
            }
            return base.Score(context, directive);
        }
    }
