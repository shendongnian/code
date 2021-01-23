    public bool `addItemToBankArray`(string name, int amm)
    {
        for (int i =0; i<listOfBankItems.Count; i++ )
        {
            if (listOfBankItems[i].Name == name)
            {
                listOfBankItems[i].Stacks += amm;
                return true;
            }
        }
    
        bankItemList item = new bankItemList(name, amm);
        listOfBankItems.Add(item);
        return true;
    }
