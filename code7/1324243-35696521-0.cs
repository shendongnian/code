    static class MyReeksExtension {
            public static IEnumerable <int> TakeRange(this IEnumerable<int> r, int start, int end) {
                return r.Where(i => i > start && i < end);
            }
        }
