    private void button1_Click(object sender, EventArgs e) {
       RemoveLastTotal();
       var newTotal = AppendPrices();
       AppendTotal(newTotal);
    }
    
    private void RemoveLastTotal() {
       var lastItemIndex = listBox2.Items.Count-1;
       if (listBox2.Items[lastItemIndex].StartsWith("Total Price:"))
       {
           listBox2.Items.RemoveAt(lastItemIndex);
       }
    }
    
    private decimal AppendPrices() {
        string TheItem = Convert.ToString(listBox1.SelectedItem);
        string[] theSplits = TheItem.Split(' ');
        string FirstSplit = theSplits[0];
        string SecondSplit = theSplits[1];
        decimal theNewTotal;
        decimal theValue;
    
        if (textBox1.Text == "") {
           listBox2.Items.Add(TheItem);
           return decimal.Parse(SecondSplit);
        } else {
            theValue = Convert.ToDecimal(SecondSplit) * Convert.ToDecimal(textBox1.Text);
          listBox2.Items.Add(textBox1.Text + "x " + TheItem);
          return theValue;
       }        
    }
    private void AppendTotal(decimal newTotal)
    {
        listBox2.Items.Add("Total Price:" + newTotal);               
    }
