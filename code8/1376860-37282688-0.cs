    private void strtoasc()
    {
        int[] ascchar=new int[tbox_string.Text.Length];// It will solve the issue
        int i = 0;
        foreach (char stg in tbox_string.Text)
        {
            ascchar[i] = Convert.ToInt32(stg);
            i++;
        }
    }
