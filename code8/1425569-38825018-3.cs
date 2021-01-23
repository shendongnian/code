    public void Company_Filter(object sender, RoutedEventArgs e)
    {
        peopleCollection.Clear();
        foreach (var person in peopleList)
        {
            if (person.Company == "AA")
                peopleCollection.Add(person);
        }
    }
