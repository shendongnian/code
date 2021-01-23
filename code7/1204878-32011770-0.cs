    [Behaviors]
    internal class DenebRightAscension
        {
        It should_have_20_hours_ = () => UUT.Degrees.ShouldEqual(20u);
        It should_have_41_minutes = () => UUT.Minutes.ShouldEqual(41u);
        It should_have_59_seconds = () => UUT.Seconds.ShouldEqual(59u);
        protected static Bearing UUT;
        }
    [Subject(typeof(HourAngle), "sexagesimal")]
    internal class when_converting_hour_angle_to_sexagesimal
    {
        Because of = () =>
        {
            RaDeneb = 20.6999491773451; // This value caused AWR-88
            UUT = new Bearing(RaDeneb);
        };
        Behaves_like<DenebRightAscension> deneb;
        protected static Bearing UUT;
        static double RaDeneb;
    }
    [Subject(typeof(Bearing), "sexagesimal")]
    internal class when_converting_to_sexagesimal
        {
        Because of = () =>
            {
            RaDeneb = 20.6999491773451; // This value caused AWR-88
            UUT = new Bearing(RaDeneb);
            };
        Behaves_like<DenebRightAscension> deneb;
        protected static Bearing UUT;
        static double RaDeneb;
        }
