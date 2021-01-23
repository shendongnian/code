    public enum VocationType { Mage, ... }
    public static class VocationFactory
    {
        public static Vocation CreateVocation(VocationType type)
        {
            switch (type)
            {
                case VocationType.Mage:
                    {
                        return new Mage();
                        break;
                    }
            }
            throw new Exception($"You did not implement type '{type}'.");
        }
    }
