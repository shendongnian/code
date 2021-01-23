    var model = new TestViewModel()
    {
        Test = new List<Test>() { new Test(), new Test(), ... }
    }
    return View("Upload", model);
