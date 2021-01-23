    private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
       Dictionary<char, EnglishRussian> letterDictionary = new Dictionary<char, EnglishRussian>();
       letterDictionary.Add('A', new EnglishRussian() {RussianLetter='ф', IndexRussian='ф', EnglishLetter='a', IndexEnglish='a' });
       //You need to add all English letters and their opposite Russian letters
       char ch = (char)e.KeyValue;       
       char yourValue;
       switch(ch)
       {
         case 'A':
            {
              yourValue= letterDictionary[ch].RussianLetter;
              break;
            }            
        }
    }
