    public interface IComposer {
        string GenerateSnippet(List<CodeTree> trees);
        void RegisterCodeTreeType<T>(T codeType) where T:CodeTree;
    }
    public abstract class ComposerBase {
        private readonly Dictionary<Type, CodeTree> _dictionary;
        public ComposerBase() {
            _dictionary = new Dictionary<Type, CodeTree>();
        }
        public void RegisterCodeTreeType<T>(T codeType) where T:CodeTree {
           _dicionary.Add(typeof(T), codeType);
        }
        public string GenerateSnippet(List<CodeTree> trees) {
            StringBuilder fullCode = new StringBuilder();
            foreach(var tree in trees) {
                fullCode.Append(_dictionary[tree.GetType()].GenerateSnippet();
            }
        }
    }
