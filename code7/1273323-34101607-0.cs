    if (EventList.SelectedItem == "Event")
    {
        newCost.TotalCost = (Event + 100);
    }
    else if (EventList.SelectedItem == "Personal")
    {
        newCost.TotalCost = (personalEvent + 150);
    }
    else if (EventList.SelectedItem == "Organisational")
    {
        newCost.TotalCost = (organisationalEvent + 170);
    }
    else
    {
        txtTotalCost.Text = ("£" + newCost.TotalCost.ToString());
    }
