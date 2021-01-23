    using(SqlConnection myConnection = new SqlConnection(
        "user id=" + Username + ";" +
        "password=" + Password + ";" +
        "server=" + Server + ";" +
        "database=" + DBName + ";" +
        "connection timeout=" + ConnectionTimeout + ";")
    ){
    
        myConnection.Open();    
    
        string currentValue = htableData["Test"].ToString().Trim();
    
        if (!(String.IsNullOrEmpty(currentValue)))
        {
    
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 form = new Form1();
            Application.Run(form);
    
            form.Dispose();
        }
    
        myConnection.Close();
    
    }
