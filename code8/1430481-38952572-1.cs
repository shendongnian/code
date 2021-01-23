    using (Reference_TraductionEntities context = new Reference_TraductionEntities())
    {
        var source = new AutoCompleteStringCollection();
        var name = from a in context.Feuil1Prenom
                   where a.PRENOMF.StartsWith(textBox1.Text )
                   select a.PRENOMF;
        source.AddRange(name.ToArray());
        textBox1.AutoCompleteCustomSource = source;
        textBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    }
