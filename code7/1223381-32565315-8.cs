    private void button2_Click(object sender, EventArgs e)
    {
        if(!gridItems.Any(gridItem => gridItem.Ordernummer == 123456){
            gridItems.Add(new GridItem{ Ordernummer = 123456, Bonnummer = 1, Volgnummer = 40, Bewerking = "1130-Lasersnijden"});
            bs.ResetBindings(false);
        }
    }
