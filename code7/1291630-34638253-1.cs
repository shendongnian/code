    private void Pudisoo_TabSelected1(object sender, ActionBar.TabEventArgs e)
    {
        SetContentView(Resource.Layout.filenamehere);
        Button btnon = FindViewById<Button> (Resource.Id.btnOn);
        Button btnOff = FindViewById<Button> (Resource.Id.btnOff);
        btnoff.Click += Btnoff_Click;
        btnon.Click += Btnon_Click1;
    }
