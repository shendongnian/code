            var hashTable = new Hashtable();
            var table = Driver.FindElement(By.Id("table"));
            int rowCount = table.FindElements(By.TagName("tr")).Count;
            for (int i = 0; i < rowCount; i++)
            {
                hashTable.Add($"row{i}", table.FindElements(By.TagName("tr"))[i].Text);
            }
