    public partial class Form1 : Form {
        private readonly CustomLexer _lexer = new CustomLexer();
        public Form1() {
            InitializeComponent();
            var editor = new ScintillaNET.Scintilla {
                Dock = DockStyle.Fill,
                
            };
            this.Controls.Add(editor);
            editor.StyleResetDefault();
            editor.Styles[Style.Default].Font = "Consolas";
            editor.Styles[Style.Default].Size = 10;
            editor.StyleClearAll();
            editor.Styles[CustomLexer.StyleText].ForeColor = Color.Black;
            editor.Styles[CustomLexer.StyleParens].ForeColor = Color.Red;
            editor.Lexer = Lexer.Container;
            editor.StyleNeeded += scintilla_StyleNeeded;
        }
        private void scintilla_StyleNeeded(object sender, StyleNeededEventArgs e) {
            var scintilla = (ScintillaNET.Scintilla)sender;
            var startPos = scintilla.GetEndStyled();
            var endPos = e.Position;
            _lexer.Style(scintilla, startPos, endPos);
        }
    }
    public class CustomLexer {
        public const int StyleText = 0;
        public const int StyleParens = 1;
        private const int STATE_TEXT = 0;
        private const int STATE_INSIDE_PARENS = 1;
        public void Style(Scintilla scintilla, int startPosition, int endPosition) {
            // Back up to the line start
            var startLine = scintilla.LineFromPosition(startPosition);
            var endLine = scintilla.LineFromPosition(endPosition);
            var fixedStartPosition = scintilla.Lines[startLine].Position;
            var fixedStopPosition = scintilla.Lines[endLine].Position + scintilla.Lines[endLine].Length;
            scintilla.StartStyling(fixedStartPosition);
            bool insideBrackets = false;
            for (var i = fixedStartPosition; i < fixedStopPosition; i++) {
                var c = (char)scintilla.GetCharAt(i);
                if (c == '{') insideBrackets = true;
                if (insideBrackets) {
                    scintilla.SetStyling(1, StyleParens);
                }
                else {
                    scintilla.SetStyling(1, StyleText);
                }
                if (c == '}') insideBrackets = false;
            }
        }
    }
