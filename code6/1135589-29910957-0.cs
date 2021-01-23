    List<models.Car> carList = carController.getCars();    
    for (int i = 0; i < carList.Count; i++) 
    {
        List<models.Product> productList = productController.getProducts(carList[i].Model);
    
        for (int j = 0; j < productList.Count; j++) 
        {
            var label = new Label();
            var productLabelsPoint = new System.Drawing.Point(200, 40 + (i * 50) + (j * 50));
            label.Location = productLabelsPoint;
            label.Size = new System.Drawing.Size(150, 15);
            label.Text = productList[j].Title;
            this.Tab.TabPages["tab1"].Controls.Add(label);
            productLabels.Add(label);
        }
    }
