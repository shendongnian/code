             List<dataObject> bindingList = new List<dataObject>();          
             bindingList.Add(new dataObject()
             {
                 Name = "Smith",
                 Number = 1
             });
             bindingList.Add(new dataObject()
             {
                 Name = "John",
                 Number = 12
             });
             bindingList.Add(new dataObject()
             {
                 Name = "Bon",
                 Number = 14
             });
            listCombobox.ItemsSource = bindingList;
            listCombobox.DisplayMemberPath = "Name";
