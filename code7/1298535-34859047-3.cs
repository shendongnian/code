    for (int i = 0; i < Kount ; i++)
    {
        Vutton = new Button();
        //...set properties
        //Also add Name:
        Vutton.Name = string.Format("Vutton{0}", i);
        //Also you can add Tag
        Vutton.Tag = i;
        Controls.Add( Vutton );
        Vutton.Click += new EventHandler(Kommon);
        //... other stuff
    }
