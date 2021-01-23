    private void button1_Click(object sender, EventArgs e) {
       RemoveLastTotal();
       AppendPrices();
       AppendTotal();
    }
    
    private void RemoveLastTotal() {
       var lastItemIndex = listBox2.Items.Count-1;
       if (listBox2.Items[lastItemIndex].StartsWith("Total Price:"))
       {
           listBox2.Items.RemoveAt(lastItemIndex);
       }
    }
    
    private void AppendPrices() {
        string TheItem = Convert.ToString(listBox1.SelectedItem);
        string[] theSplits = TheItem.Split(' ');
        string FirstSplit = theSplits[0];
        string SecondSplit = theSplits[1];
        decimal theNewTotal;
        decimal theValue;
    
        if (textBox1.Text == "") {
           listBox2.Items.Add(TheItem);
        } else {
            theValue = Convert.ToDecimal(SecondSplit) * Convert.ToDecimal(textBox1.Text);
          listBox2.Items.Add(textBox1.Text + " x " + TheItem + " = " + theValue);
       }        
    }
    private void AppendTotal()
    {
        var total = 0;
        foreach(var item in listBox2.Items)
        {
          var splits = item.Split(' ');
          total += decimal.parse(splits[splits.length-1]);
        }
        listBox2.Items.Add("Total Price:" + total);               
    }
