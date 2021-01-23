        public IActionResult Index()
        {
            // Set Cache
            var myList = new List<string>();
            myList.Add("lorem");
            this.cache.Set("MyKey", myList, new MemoryCacheEntryOptions());
            return View();
        }
