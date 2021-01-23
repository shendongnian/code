    Usuario usuario1 = new Usuario("name1", "lastname1");
    Usuario usuario2 = new Usuario("name2", "lastname2");
    Usuario usuarioN = new Usuario("nameN", "lastnameN");
    
    IList<Usuario> list = new List<Usuario>();
    list.Add(usuario1);
    list.Add(usuario2);
    list.Add(usuarioN);
            
    cmbItems.DataSource = list;
    //property names
    cmbItems.DisplayMember = "name";
    cmbItems.ValueMember = "lastname";
    
    cmbItems.SelectedItem = usuarioN;
