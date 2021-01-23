    int counter = 0;
    
        foreach (TableRow tr in allVisibleRows)
        {
                destination = myTableCol[counter]["Route"].ToString();
                dateGo = myTableCol[counter]["DepartureDate"].ToString();
                dateEnd = myTableCol[counter]["ReturnDate"].ToString();
                kmInCity = myTableCol[counter]["TraveledInCity"].ToString();
                kmOutCity = myTableCol[counter]["TraveledOutCity"].ToString();
        
                ((TextBox)tr.Cells[1].Controls[0]).Text = destination;
                ((DateTimeControl)tr.Cells[2].Controls[0]).SelectedDate = DateTime.Parse(dateGo);
                ((DateTimeControl)tr.Cells[3].Controls[0]).SelectedDate = DateTime.Parse(dateEnd);
                ((TextBox)tr.Cells[4].Controls[0]).Text = kmInCity;
                ((TextBox)tr.Cells[5].Controls[0]).Text = kmOutCity;
                 
                counter+;
        }
