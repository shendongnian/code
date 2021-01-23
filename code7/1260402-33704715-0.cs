    for (int i = lstMaster.Count - 1; i > 0; i--)
    {
        bool delete = false;
        
        for (int j = lstChildcare.Count - 1; j > 0; j--)
        {
            if (lstChildcare[j].school_license == lstMaster[i].school_license)
            {
                textboxStatus.AppendText(MediaTypeNames.Text = "Removing duplicate row: " + i + " School: " + lstMaster[i].school_name + Environment.NewLine);
                delete = true;
                counter++;
            }
        }
        if(delete)
            lstMaster.RemoveAt(i);
    }
