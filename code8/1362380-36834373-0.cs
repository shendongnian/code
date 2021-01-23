       if (MedNameAdd.Text != null && MedQuantAdd.Text != null && QuantType.Text != null)
       {
           var medlist = MedList.ItemsSource as List<string>;
           int i = 0;
           medlist.Add(MedNameAdd.Text + "   " + MedQuantAdd.Text + "     " + QuantType.Text);
           Address.Text = medlist[i];
           i++; 
        }
