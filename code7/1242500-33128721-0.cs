        public static float ClosestTo(this IEnumerable<float> collection, float target)
        {
            float a = collection.Where(x => x >= target).OrderBy(x => x - target).First();
            float b = collection.Where(x => x < target).OrderBy(x => Math.Abs(target - x)).First();
            return a.Equals(b) ? a : Math.Min(a, b);
        }
