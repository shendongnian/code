    // IF (Value is empty => use "").ToString() <-- IsNullOrEmpty
    if (!string.IsNullOrEmpty(row.Cells[clm.Index].Value ?? "").ToString())
    {
        notAvailable = false;
        break;
    }
