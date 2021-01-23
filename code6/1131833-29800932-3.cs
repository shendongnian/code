    string[] sentence = new string[] { "I like C++.", "I like C#.", "I like Java." };
    
                for (int i = 0; i < sentence.Length; i++)
                {
                    xyz:
                    
                    for (int j = i; j < sentence.Length; j++)
                    {
                        richTextBox1.Text += sentence[j] + "\n";
                        break;
                    }
                    
                     i++;
                     if (i == sentence.Length) { break; }
                     goto xyz;
                }
