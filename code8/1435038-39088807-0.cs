        public static string ShowTree(List<TreeModel> source) {
            var empty = new StringRef();
            source.Where(s => s.ParentId == null).ToList().ForEach(s => ShowNode(source, s, empty));
            return empty.Text;
        }
        private static void ShowNode(List<TreeModel> source, TreeModel model, StringRef text, int depth = 0) {
            text.Text += Enumerable.Repeat(" ", depth++).Aggregate("", (s, s1) => s + s1) + model.Name + "\n";
            source.ForEach(m => {
                if (model.Id == m.ParentId) ShowNode(source, m, text, depth);
            });
        }
        public class StringRef {
            public StringRef() {
                Text = "";
            }
            public string Text { get; set; }
        }
