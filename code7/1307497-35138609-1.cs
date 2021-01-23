    public partial class Form1 : Form
    {
        public char[] vowel = new char[] {'a', 'e', 'i', 'o', 'u', 'y'};
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //var programVowelGuess = new vowel();
            int count = 0;
            string wordEntry = textBox1.Text.ToLower();
            for (int i = 0; i < wordEntry.Length; i++)
            {
                if (vowel.Contains(wordEntry[i]))
                {
                    count++;
                }
            }
            label1.Text = count.ToString();
        }
    }
