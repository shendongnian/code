    string checkedMonths = "";
        public void GetCheckedMonths()                                              //To get all checked Months
        {
            string c = "";
            for (int i = 0; i < checkedListBoxMonths.Items.Count; i++)
            {
                if (checkedListBoxMonths.GetItemChecked(i))
                {
                    c = (string)checkedListBoxMonths.Items[i].ToString();
                    checkedMonths = checkedMonths +", "+ c;                         //TO add selected moths with , in between them
                }
            }
        }
