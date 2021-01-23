    public class Length
    {
        // ...
    
        public static IFluentSyntaxProvider MultiplesOf(Length divisor)
        {
            return new FluentSyntaxProvider(divisor);
        }
    
        public interface IFluentSyntaxProvider
        {
            List<Length> In(Length dividend);
        }
        private class FluentSyntaxProvider : IFluentSyntaxProvider
        {
            private Length divisor;
            
            public FluentSyntaxProvider(Length divisor)
            {
                this.divisor = divisor;
            }
    
            public List<Length> In(Length dividend)
            {
                double inchEnumeration = divisor.Inches;
                List<Length> multiples = new List<Length>();
    
                while (inchEnumeration <= dividend.Inches)
                {
                    multiples.Add(new Length(inchEnumeration, Length.Unit.Inch));
                    inchEnumeration += divisor.Inches;
                }
    
                return multiples;
            }
        }
    }
