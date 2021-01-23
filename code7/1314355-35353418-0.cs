       public async Task<IActionResult> Index(string q)
        {
            //Code
            var mySvc = new MyService();
            var svcResponse = await mySvc.GetAsync(q);
            //More code
        }
