     private void metroButtonAdicionar_Click(object sender, EventArgs e)
     {        
        foreach(Pessoa p in todos)
        {
            if (someCondition) //p.getusername() == todos[i++].getusername()
            {
              p.setusername(metroTextBoxUsername.Text);
              novaListaPessoa.Add(p)
            }
        }   
    }
