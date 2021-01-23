    public static class SerializationFlags
    {
        [ThreadStatic]
        static bool studentGuidOnly;
        public static bool StudentGuidOnly 
        {
            get { return studentGuidOnly; }
            set { studentGuidOnly = value; }
        }
    }
