        Object tempObjCB;
    
        private void onClick(object sender, EventArgs e)
        {
                tempObjCB = sender;
        }
    
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
                myStruct item = new myStruct(){objCB = tempObjCB};
                item.ViewType = (rbLine.IsChecked == true) ? "SingleLine" : "Area";
                mylist.Add(item);
        }
