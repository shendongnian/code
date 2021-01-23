    public void save(){
    String username = txtUsername.Text;
    String password = txtPassword.Text;
    File.WriteAllText(path, username + ";" + password);
    }
    
    public void load(){
    String parameters = File.ReadAllText(path);
    String[] splitted = parameters.split(';');
    txtUsername.Text = splitted[0];
    txtPassword.Text = splitted[1];
    }
