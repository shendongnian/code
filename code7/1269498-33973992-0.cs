    private void listBox1_SelectedIndexChanged(object sender, System.EventArgs e)
    {
         string size_selected = listBox1.SelectedItem.ToString();
         size.Add(size_selected);
         if(size_selected.ToUpper() == ("8 Inch").ToUpper()){
              global.numberofeachsize[0] +=1;
         }
         if(size_selected.ToUpper() == ("10 Inch").ToUpper()){
              global.numberofeachsize[1] +=1;
         }
         if(size_selected.ToUpper() == ("12 Inch").ToUpper()){
              global.numberofeachsize[2] +=1;
         }
         if(size_selected.ToUpper() == ("14 Inch").ToUpper()){
              global.numberofeachsize[3] +=1;
         }
    }
