    foreach(TextBox txt in list)
    {
        Double temp;
        if(Double.TryParse(txt.Text, temp) == true)
        {
            //save or use valid value 
            Debug.Print(temp.ToString());
        }
        else
        {
            messagebox.Show("please fill in the boxes");
            break;
        }
    }
