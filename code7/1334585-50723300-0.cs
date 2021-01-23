        var template = new XLTemplate(@".\Templates\report.xlsx");
        using (var db = new DbDemos())
        {
            var cust = db.customers.LoadWith(c => c.Orders).First();
            template.AddVariable(cust);
            template.Generate();
        }
        template.SaveAs(outputFile);
