    public class A: SomeClass
    {
        public virtual TimeZoneInfo Timezone { get; set; } //note virtual keyword
        public A()
        {
            Timezone = TimeZoneInfo.Utc;
        }
    }
    public class B: A
    {
        public override TimeZoneInfo Timezone { get; set; } //note override keyword, return type is not changed
        public B()
        {
        }
    }
