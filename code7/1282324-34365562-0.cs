    for (int i = 0; i <= cboDiameter.Items.Count-1; i++)
                    {
                        double.TryParse(cboDiameter.GetItemText(cboDiameter.Items[i]), out val);
                        if (val == formPipe.diameter)
                        {
                            myIndex = i;
                        }
                    }
