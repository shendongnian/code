    public Order BuildOrder()
    {
        var currentOrder = new Order();
        currentOrder.HasOilChange = oilChangeCheckBox.CheckState;
        currentOrder.HasLubeJob = lubeJobCheckBox.CheckState;
        currentOrder.HasRadiatorRush = radiatorRushCheckBox.CheckState;
        currentOrder.HasTransmissionFlush = transmissionFlushCheckBox.CheckState;
        currentOrder.HasInspection = inspectionCheckBox.CheckState;
        currentOrder.HasMufflerReplacement = replaceMufflerCheckBox.CheckState;
        currentOrder.HasTireRotation = tireRotationCheckBox.CheckState;
        currentOrder.PartsCost = Decimal.Parse(partsTextBox.Text);
        currentOrder.LaborsCost = Decimal.Parse(laborTextBox.Text);
        return order;
    }
    
    private void calculateButton_Click(object sender, EventArgs e)
    {
       var totalCalculator = new OrderCalculator();
       var partsCalculator = new PartsCalculator();
       var serviceCalculator = new ServiceCalculator();
       var order = BuildOrder();
       var totalCost = totalCalculator.CalculateTotal(order);
       var partsCost = partsCalculator.CalculateTotal(order);
       var serviceCost = serviceCalculator.CalculateTotal(order);
       //Do what you need to with the totals here;
       totalFeesAnsLabelBox.Text = totalCost.ToString();
    }
