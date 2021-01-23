    private void btSaveMovie_Click(object sender, EventArgs e)
    {
        var MyMovie = new Film(txtNum.Text, txtTitre.Text, cbCateg.Text);
        ListeFilms.Add(MyMovie);
        foreach (Film x in ListeFilms)
        {
            txtAffichage.AppendText(x.Numero + " - " + x.Titre + "- " + x.Categorie));
        }
    }
