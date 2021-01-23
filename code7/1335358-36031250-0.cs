    protected void GA_Total(object sender, EventArgs e)
    {
        // Generalized Anxiety Total 
        int GATotal = 0;
    
        GATotal += sumSelectedItems(radioButtonList);
        GATotal += sumSelectedItems(radioButtonList1);
        GATotal += sumSelectedItems(radioButtonList2);
        GATotal += sumSelectedItems(radioButtonList3);
        GATotal += sumSelectedItems(radioButtonList4);
        GATotal += sumSelectedItems(radioButtonList5);
    
        Label1.Text = GATotal.toString();
    }
    
    
    private int sumSelectedItems(RadioButtonList list)
    {
        int sum = 0;
        for (int i = 0; i < list.Items.Count; i++)
        {
            if (list.Items[i].Selected)
            {
                sum += i;
            }
        }
    
        return sum;
    }
