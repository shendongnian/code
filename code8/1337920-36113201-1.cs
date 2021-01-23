    class BaseClass
    {
        /// <summary>Time To Live.</summary>
        public float TTL;
        ...
    }
    class DerivedClass : BaseClass
    {
        /// <summary>Time To Live.</summary>
        /// <para>Also stops ticking after living time is longer than TTL.</para>
        public float TTL
        {
            get { return base.TTL; }
            set { base.TTL = value; }
        }
        ...
    }
