    public static class StringBuilderExtension {
        public static StringBuilder AppendAll(
            this StringBuilder stringBuilder,
            params string[] items
        ) {
            foreach(var item in items) {
                stringBuilder.Append(item);
            }
            return stringBuilder;
        }
    }
