    public Form1()
    {
    string inform;
    InitializeComponent();
    MySqlConnection conn = null;
    MySqlDataReader mainrdr = null;
    if (open_connection())   {
      string query = "SELECT * FROM res_ev;";
      MySqlCommand cmd = new MySqlCommand(query, conn);
      mainrdr = cmd.ExecuteReader();
      While(mainrdr.Read())
      {
        Label label = new Label();
        Button button = new Button();
        ...
        ... //DEFINING PROPERTY OF THESE OBJECTS
        ...
        inform = mainrdr.GetString(0);
        button.Click += new EventHandler((s, e) => remove(s, e, inform));
        ...
        ...
      }
      ...
      }
    }
