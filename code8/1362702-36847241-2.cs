      public IActionResult Test()
        {
            Object1 obj1 = new Object1() { TestString1 = "test1" };
            Object2 obj2 = new Object2() { TestString2 = "test2" };
            TestViewModel vm = new TestViewModel(obj1, obj2);
            return View(vm);
        }
        [HttpPost]
        public IActionResult Test(TestViewModel vm)
        {
            _logger.LogDebug(vm.Test1.TestString1);
            _logger.LogDebug(vm.Test2.TestString2);
            return View(vm);
        }
