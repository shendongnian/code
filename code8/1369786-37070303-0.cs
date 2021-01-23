    richTextBox1.Text = "včľťšľžšžščýščýťčáčáčťáčáťýčťž";            
    string text1 = richTextBox1.Text.Normalize(NormalizationForm.FormD);
    string pattern = @"\p{M}";
    string text2 = Regex.Replace(text1, pattern, "�");
    richTextBox2.Text = text2;
