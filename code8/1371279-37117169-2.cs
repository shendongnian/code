        private int totalPoints = 100;
        protected void ddLuuk_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddGabriel.Items.Clear();
            var value = ddLuuk.SelectedValue;
            
            int pointsToGive = totalPoints - Convert.ToInt32(value);
    
            for (int i = 0; i < pointsToGive ; i++)
            {
                ddGabriel.Items.Add(i.ToString());
            }
        }
