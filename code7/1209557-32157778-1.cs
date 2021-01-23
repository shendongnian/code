    if (picbox[i].InvokeRequired)
    {
        picbox[i].Invoke(new Action(() =>
        {
            picbox[i].BorderStyle = BorderStyle.FixedSingle;
        }));
    }
    else
    {
          picbox[i].BorderStyle = BorderStyle.FixedSingle;
    }
