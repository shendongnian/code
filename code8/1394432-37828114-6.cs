    // If not null
    if(row.Cells[clm.Index].Value != null)
    {
        // If string of value is empty
        if(row.Cells[clm.Index].Value.ToString() != "")
        {
            notAvailable = false;
            break;
        }
    }
