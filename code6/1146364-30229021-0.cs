    public class Film
    {
        public Film(string Num, string Title, string Categ)
        {
             this.Numero = Num;
             this.Titre = Title;
             this.Categorie = Categ;
        }
    
        public string Numero;
        public string Titre;
        public string Categorie;
    
        public override string ToString()
        {
            return Numero.ToString() + " " + Titre.ToString() + " " + Categorie.ToString();
        }
    }
