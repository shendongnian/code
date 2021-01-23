    public char[] vowel = {'a', 'e', 'i', 'o', 'u', 'y'};
    
    private void button1_Click(object sender, EventArgs e)
    {
        var programVowelGuess = vowel;
        int count = 0;
        string wordEntry = (textBox1.Text).ToLower();
        for (int i = 0; i < wordEntry.Length; i++)
        { if (textBox1.Text.Contains(programVowelGuess[i]))
            { count++;
            }
        }
        var vowelCount = Convert.ToString(count);
        label1.Text = vowelCount;
    }
