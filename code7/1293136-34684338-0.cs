        [HttpPost]
        public IActionResult Index(PowerShellCmd script)
        {
            PowerShellModule execute = new PowerShellModule();
            var results = execute.ExecuteCode(script);
            StringBuilder builder = new StringBuilder();
            foreach (var psObject in results)
            {
                // Convert the Base Object to a string and append it to the string builder.
                // Add \r\n for line breaks
                builder.AppendLine(psObject.BaseObject.ToString());
            }
            MyModel myModel = new MyModel();
            myModel.Data = builder.ToString();
            return View(myModel); // Transfer data to view
        }
