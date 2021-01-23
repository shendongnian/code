            ddGabriel.Items.Clear();
            var value = (int)ddLuuk.SelectedValue;
            if (value == 10)
            {
                Enumerable.Range(0, 1).ToList().ForEach(i => ddGabriel.Items.Add(i.ToString()));
            }
            else if (value < 10)
            {
                Enumerable.Range(1, 10 - value).ToList().ForEach(i => ddGabriel.Items.Add(i.ToString()));
            }
