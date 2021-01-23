    You have tons of options here, I'd recommend you start reading [here][3].
        private int calculateSum(string text1, string text2, string text3, string text4, string text5, string text6, string text7, string text8)
        {
            int A, B, C, D, E, F, G, H;
            try
            {
                A = int.Parse(TextBox1);
                B = int.Parse(TextBox2);
                C = int.Parse(TextBox3);
                D = int.Parse(TextBox4);
                E = int.Parse(TextBox5);
                F = int.Parse(TextBox6);
                G = int.Parse(TextBox7);
                H = int.Parse(TextBox8);
            }
            catch (FromatException)
            {
                MessageBox.Show("Ooops! You entered an invalid number.");
            }
            catch (OverflowEcxeption)
            {
                MessageBox.Show("Ooops! You entered an number that it too big.");
            }
            return A + B + C + D + E + F + G + H;
        }
