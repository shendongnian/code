    using DiffMatchPatch;
    namespace RTF_diff
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
            InitializeComponent();
        }
        // this is the diff object;
        diff_match_patch DIFF = new diff_match_patch();
        // these are the diffs
        List<Diff> diffs;
        // chunks for formatting the two RTBs:
        List<Chunk> chunklist1; 
        List<Chunk> chunklist2;
        // two color lists:
        Color[] colors1 = new Color[3] { Color.LightGreen, Color.LightSalmon, Color.White, };
        Color[] colors2 = new Color[3] { Color.LightSalmon, Color.LightGreen, Color.White };
        public struct Chunk
        {
            public int startpos;
            public int length;
            public Color BackColor;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            diffs = DIFF.diff_main(RTB1.Text, RTB2.Text);
            chunklist1 = collectChunks(RTB1);
            chunklist2 = collectChunks(RTB2);
            paintChunks(RTB1, chunklist1);
            paintChunks(RTB2, chunklist2);
            RTB1.SelectionLength = 0;
            RTB2.SelectionLength = 0;
        }
        List<Chunk> collectChunks(RichTextBox RTB)
        {
            RTB.Text = "";
            List<Chunk> chunkList = new List<Chunk>();
            foreach (Diff d in diffs)
            {
                Chunk ch = new Chunk();
                int length = RTB.TextLength;
                RTB.AppendText(d.text);
                ch.startpos = length;
                ch.length = d.text.Length;
                ch.BackColor = RTB == RTB1 ? colors1[(int)d.operation]: colors2[(int)d.operation];
                chunkList.Add(ch);
            }
            return chunkList;
        }
        void paintChunks(RichTextBox RTB, List<Chunk> theChunks)
        {
            RTB.Text = "";
            foreach( Diff d in diffs) RTB.AppendText(d.text);
            foreach (Chunk ch in theChunks)
            {
                RTB.Select(ch.startpos, ch.length);
                RTB.SelectionBackColor = ch.BackColor;
            }
        }
      }
    }
