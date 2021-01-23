            using System.Globalization;
          
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string[] text = myString.Split();
            for(int i = 0; i < text.Length; i++)
            {   //Check for zero-length strings, because these will throw an
                //index out of range exception in Char.IsLetter
                if (text[i].Length > 0 && Char.IsLetter(text[i][0]))
                {
                    text[i] = textInfo.ToTitleCase(text[i]);
                }
            }
