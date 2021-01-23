    using System.Windows.Forms;
    namespace Windowspplication1_cs
    {
        public static class SpecialMyDialogs
        {
            public static bool Question(string Text)
            {
                return (MessageBox.Show(Text, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
            }
            public static bool Question(string Text, string Title)
            {
                return (MessageBox.Show(Text, Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
            }
            public static bool QuestionOkayCancel(string Text)
            {
                return (MessageBox.Show(Text, "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
            }
            public static bool QuestionOkayCancel(string Text, string Title)
            {
                return (MessageBox.Show(Text, Title, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes);
            }
        }
    }
