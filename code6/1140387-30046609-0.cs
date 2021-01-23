    int value;
    int result = 0;
    foreach (TextBox tb in txt)
    {
        if(tb !=null)
        {
            if (int.TryParse(tb.Text, out value))
            {
                result += value;
            }
        }
    }
    label3.Text = Convert.ToString(result);
