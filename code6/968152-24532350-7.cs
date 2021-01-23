    SqlConnection conn = GetConnSomehow();
    SqlCommand cmd = conn.CreateCommand(); 
    using ( conn ) {
        cmd.ExecuteSomething();
    }
    // ... time passes ...
    // This won't compile, according to alykins.
    conn.Open();
