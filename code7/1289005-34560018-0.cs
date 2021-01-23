    for (int i = 0; i < chkBox.Items.Count; i++)
            {
                if (i > 0)
                {
                    if (chkBox.Items[i].Selected)
                    {
                        if (chkBox.Items[i - 1].Selected)
                            continue;
                        else
                        {
                            _isSequentialSelected = false;
                            break;
                        }
                    }
                }
            }
