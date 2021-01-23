    spinner.ItemSelected += Spinner_ItemSelected;
    void Spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
    {
        switch(e.Position)
        {
           case 0:
             StartActivity(...);
             break;
           ...
         }
    }
