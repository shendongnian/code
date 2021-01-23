     public Product GetChartData()
        {
            Product objproduct = new Product();
            List<string> yr = null;
            List<string> sal = null;
            List<string> pur = null;
            yr = db.tblCharts.Select(y => y.Years).ToList();
            sal = db.tblCharts.Select(y => y.Sale).ToList();
            pur = db.tblCharts.Select(y => y.Purchase).ToList();
            objproduct.Year = string.Join(",", yr);
            objproduct.Sale = string.Join(",", sal);
            objproduct.Purchase = string.Join(",", pur);
            return objproduct;
        }
