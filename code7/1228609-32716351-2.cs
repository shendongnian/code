        // In the class
        static HttpClient client = new HttpClient();
        // Put the following code where you want to initialize the class
        // It can be the static constructor or a one-time initializer
        client.BaseAddress = new Uri("http://localhost:4354/api/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
