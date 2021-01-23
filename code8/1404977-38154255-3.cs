    public static class ActionRules
    {
        //First, you want a few static methods which can start a chain:
        public static IActionConfiguration Damage(int strength)
        {
            return new DamageActionConfiguration(strength);
        }
        public static IActionConfiguration Status(Status status)
        {
            return new CauseStatusActionConfiguration(status);
        }
        // Next, some extension methods which allow you to chain things together
        // This is really the glue that makes this whole solution easy to use
        public static IActionConfiguration WithDamage(this IActionConfiguration source, int strength)
        {
            return new CompositeActionConfiguration(source, Damage(strength));
        }
        public static IActionConfiguration WithStatus(this IActionConfiguration source, Status status)
        {
            return new CompositeActionConfiguration(source, Status(status));
        }
    }
