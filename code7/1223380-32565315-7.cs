    private void button2_Click(object sender, EventArgs e)
    {
        //ADD ITEMS
        var gridToAdd = new GridItem{ Ordernummer = 123456, Bonnummer = 1, Volgnummer = 40, Bewerking = "1130-Lasersnijden"};
        if(!gridItems.Contains(gridToAdd){
            gridItems.Add(gridToAdd);
            bs.ResetBindings(false);
        }
    }
