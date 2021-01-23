        List<String> cardsList = new List<String>();
        string[] stringSeparators = new string[] { "CARD#" };
        foreach (Description d in CardTrans)
        {
            if (d.Desc3.Contains("CARD#"))
            {
                string[] text = d.Desc3.Split(stringSeparators, StringSplitOptions.None);
                if (!(cardsList.Contains(text[1])))
                    cardsList.Add(text[1]);
            }
        }
