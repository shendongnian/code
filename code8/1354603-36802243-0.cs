        public static bool IsAnyOf(this object Obj,params string[] TypeNames)
        {
            return Obj.GetType().Name.In(TypeNames);
        }
        public static bool In(this string Needle,params string [] Haystack)
        {
            foreach (string straw in Haystack)
                if (straw == Needle)
                    return true;
            return false;
        }
