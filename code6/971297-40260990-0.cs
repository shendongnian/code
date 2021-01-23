    private void comPortList_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
           
            if (comPortList.IsDropDownOpen==true)
            {
                txtMsgBox.AppendText("MouseDirectlyOverChanged\n");
                txtMsgBox.ScrollToEnd();
                comPortList.IsDropDownOpen = false;
            }
                
        }
