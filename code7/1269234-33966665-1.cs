    public Form1()
    {
        users.Add (new User() { id = 0, userName = "user1", password = "password123", savingsAcct = 2000, checkAcct = 2500 });
        users.Add (new User() { id = 1, userName = "user2", password = "password234", savingsAcct = 3000, checkAcct = 4500 });
        users.Add (new User() { id = 2, userName = "user3", password = "pass345", savingsAcct = 3000, checkAcct = 5000 });
        InitializeComponent();
    }
