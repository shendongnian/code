        public static class Vector2Extensions
        {
            public static IEnumerable<double> Values(this Vector2 vec)
            {
                if (vec == null)
                    throw new ArgumentNullException();
                yield return vec.X;
                yield return vec.Y;
            }
        }
