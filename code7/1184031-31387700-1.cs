    public class Parser {
        private const string COMPONENT_MARKER = "srvrmgr";
        private readonly IParserBehaviors _behaviors;
        public Parser(IParserBehaviors behaviors) {
            _behaviors = behaviors;
        }
        public void ReadFile(string filename) {
            // bla bla
            foreach (string line in linesOfFile) {
                // maintain some state
                if (line.StartsWith(COMPONENT_MARKER)) {
                    DataTable table = _behaviors.ProduceTableForCurrentComponent();
                    // save table to the database
                    _behaviors.StartNextComponent();
                }
                else if (/* condition */) {
                    // parse some text
                    _behaviors.LoadNewDataRow(values);
                }
            }
        }
    }
