    int[] dizi = new int[listBox1.Items.Count]; //here is int array instead of string array, put generic size, just as many as the listBox1.Items.Count will do
    for (int i = 0; i < listBox1.Items.Count; i++) {
        int listBoxIntValue = 0;
        bool isInt = int.TryParse(listBox1.Items[i].ToString(), out listBoxIntValue); //Try to parse the listBox1 item
        if(isInt) //if the parse is successful
            dizi[i] = listBoxIntValue; //take it as array of integer element, rather than string element
        //here, I put the safe-guard by TryParse, just in case the listBox item is not necessarily valid number. 
        //But provided all your listBox item is in the right format, you could easily use Convert.ToInt32(listBox1.Items[i].ToString()) instead
    }
    Array.Sort(dizi); //sort array of integer
    label2.Text = dizi[0].ToString(); //this should work
