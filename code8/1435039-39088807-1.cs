        public static string ShowTree(List<TreeModel> source) {
            var empty = new StringBuilder();
            source.Where(s => s.ParentId == null).ToList().ForEach(s => ShowNode(source, s, empty));
            return empty.ToString();
        }
        private static void ShowNode(List<TreeModel> source, TreeModel model, StringBuilder text, int depth = 0) {
            text.Append(Enumerable.Repeat(" ", depth++).Aggregate("", (s, s1) => s + s1) + model.Name + "\n");
            source.ForEach(m => {
                if (model.Id == m.ParentId) ShowNode(source, m, text, depth);
            });
        }
