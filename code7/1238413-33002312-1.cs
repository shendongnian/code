    if (word.Contains(letter))
        {
            char[] letters = word.ToCharArray();
            for (int i = 0; i < letters.Length; i++)
            {
                if (letters[i] == letter)
                    labels[i].Text = letter.ToString();//Line gives out of rage error 
            }
            foreach (Label l in labels)
            if (l.Text == "_") return;
            MessageBox.Show("You have won", "Congrats");
            ResetGame();
        }
