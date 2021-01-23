    private void Pudisoo_TabSelected1(object sender, ActionBar.TabEventArgs e)
    {
        SetContentView(Resource.Layout.filenamehere);
        Button btnOn = FindViewById<Button> (Resource.Id.btnOn);
        Button btnOff = FindViewById<Button> (Resource.Id.btnOff);
        btnOff.Click += Btnoff_Click;
        btnOn.Click += Btnon_Click1;
    }
