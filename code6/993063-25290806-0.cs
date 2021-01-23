    public class NoCacheAttribute : OutputCacheAttribute
    {
        public NoCacheAttribute()
        {
            Location = OutputCacheLocation.None;
            NoStore = true;
            Duration = 0;
            VaryByParam = "None";
        }
    }
