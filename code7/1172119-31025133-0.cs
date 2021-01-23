    public Form1()
    {
        InitializeComponent();
        tmLoop.Start();
        string selectSQL;
        selectSQL = "SELECT * from locaties";       
        MySqlConnection conn = new MySqlConnection("Server=localhost;Database=patn4lj1;Uid=root;Pwd=root;");
        MySqlCommand command = new MySqlCommand(selectSQL, conn);
        MySqlDataReader reader;
        List<Point> Locaties = new List<Point>();
        try
        {
            conn.Open();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                int xPos = reader.GetInt32(0);
                int yPos = reader.GetInt32(1);
                Locaties.Add(new Point(xPos,yPos));
            }
            reader.Close();
        }
        catch (Exception)
        {
            MessageBox.Show("niks kunnen vinden uit de database!");
        }
        finally
        {
            conn.Close();
        }
     }
