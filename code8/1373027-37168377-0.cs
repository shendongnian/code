       // Please, notice "listBox4"
       private void listBox4_SelectedIndexChanged(object sender, EventArgs e) {
         String selected = listBox4.SelectedItem as String;
    
         // we don't want blinking - too many re-draws
         combobox1.BeginUpdate();
    
         try { 
           //DONE: do not forget to remove old items
           combobox1.Items.Clear();
    
           if (selected == "BE") {
             combobox1.Items.AddRange("CSE", "IT", "ME", "EX", "CE");
           else if (selected == "Pharmacy") {
             combobox1.Items.AddRange("Pharmaceutical Chemistry", "Pharmacology");
           else if (selected == "MBA") 
             combobox1.Items.AddRange("Retail Management", "HR");  
         finally {
           combobox1.EndUpdate();
         }  
       }
