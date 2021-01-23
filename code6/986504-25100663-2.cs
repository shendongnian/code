        public static bool AreDimensionsEqual(IEnumerable<Vector> vectors)
        {
            int dimensions = vectors.First().Dimension;
            return vectors.All(v => v.Dimension == dimensions);
        }
