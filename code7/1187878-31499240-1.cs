        public void fillAvalableReportsDropDownBox()
        {
            if (CustomerListView.SelectedItems.Count > 0) 
            {
                clearAvailableReportsDropDownBox();
                if (CustomerListView.SelectedItems.Count == 0)
                {
                }
                else if (CustomerListView.SelectedItems.Count > 0)
                {
                    int selIndex = CustomerListView.SelectedIndices[0];
                    if (selIndex >= 0 && selIndex < ReportList.Count)
                    {
                        int COUNT = ReportList.Count;
                        int x = 0;
                        while (x < COUNT)
                        {
                            if (ReportList[x].getCustomerName().Contains(CustomerList[selIndex].getFirstName() + " " + CustomerList[selIndex].getLastName()))
                            {
                                AvailableReportsDropDownBox.Items.Add(Convert.ToString(ReportList[x].getComplexID()));
                            }
                            x++;
                        }
                    }
                }
            }
        }
