    private void ApplyLanguage (CultureInfo ci)
    {
        Assembly a = Assembly.Load("CoffeeShop");
        ResourceManager rm = new ResourceManager("CoffeeShop.Languages.Lang", a);
        BtnCapuchino.Text = rm.GetString("Cappucino", ci);
        BtnCinnamon.Text = rm.GetString("Cinnamon", ci);
        BtnEspresso.Text = rm.GetString("Espresso", ci);
        BtnDecaffeinedCoffee.Text = rm.GetString("DecaffeinedCoffee", ci);
        BtnMilk.Text = rm.GetString("Milk", ci);
        BtnSugar.Text = rm.GetString("Sugar", ci);
        BtnBack.Text = rm.GetString("Clear", ci);
        Bulgarian.Text = rm.GetString("LanguageBulgarian", ci);
        textBox1.Text = rm.GetString("Bill", ci);
        CoffeeShop.ActiveForm.Text = rm.GetString("CoffeeShop", ci);
        Bulgarian.Text = rm.GetString("LanguageBulgarian", ci);
        BtnBuy.Text = rm.GetString("Buy", ci);
    	ShowInformation(this, null);
    }
    
