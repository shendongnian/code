       public void Search(string searchTerm)
        {
            var allLines = File.ReadAllLines("products.txt");
            int nonMatchingLineCount = allLines.Where(line => !line.Contains(searchTerm)).Count();
    
            textBlock.Text = nonMatchingLines.Count().ToString();
    
            productNameBlock.Text = allLines[counter];
            customerNameBlock.Text = allLines[counter + 1];
            firmwareBlock.Text = allLines[counter + 2];
        }
