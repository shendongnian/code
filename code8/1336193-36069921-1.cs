    if (favouritesCheckBox.IsChecked == true)
    {
        for (int i = 0; i <= 48; i++)
        {
            int id = favouriteContractList[i];
            if (id != 0)
            {
                criteria.Add(new Predicate<ContractModel>(x => x.ID == id));
            }
    }
