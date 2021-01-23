    void Main() {
        ThisIsAnEnum.typeKilom.ConvertSomething(1, 2);
    }
    
    public enum ThisIsAnEnum {
        typeKilom,
        typeMillm,
    }
    
    public static class ThisIsAnEnumExtensions {
        // extension method
        public static double ConvertSomething(this ThisIsAnEnum @this, double dbl1, double dbl2) {
            return dbl1 + dbl2; // do stuff
        }
    }
