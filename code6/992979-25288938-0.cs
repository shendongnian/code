           string Deneme = "Deneme Deneme Deneme Deneme DenemeDeneme Deneme Deneme Deneme
                            Deneme Deneme Deneme DenemeDeneme ";
            string Sonuc = "";
 
            while (Deneme.Length > 0)
            {
                Sonuc += new String(Deneme.Take(3).ToArray()) + Environment.NewLine;
                Deneme= Deneme.Remove(0, Deneme.Length >= 3 ? 3 : Deneme.Length);  
            }
